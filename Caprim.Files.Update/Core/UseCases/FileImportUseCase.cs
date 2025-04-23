using Caprim.Files.Update.Core.Ports.Input;
using Caprim.Files.Update.Core.Ports.Output;
using Caprim.Files.Update.Core.Strategy;
using Caprim.Files.Update.Domain.Models;
using Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update.Core.UseCases;

public class FileImportUseCase : IFileImportUseCase
{
    private readonly ITradeRepository<BinanceP2P> _p2pRepository;
    private readonly ITradeRepository<BinanceSpotHistory> _spotRepository;
    private readonly IFileProcessorFactory _fileProcessorFactory;
    private readonly ILogger<FileImportUseCase> _logger;

    public FileImportUseCase(
        ITradeRepository<BinanceP2P> p2pRepository,
        ITradeRepository<BinanceSpotHistory> spotRepository,
        IFileProcessorFactory fileProcessorFactory,
        ILogger<FileImportUseCase> logger)
    {
        _p2pRepository = p2pRepository;
        _spotRepository = spotRepository;
        _fileProcessorFactory = fileProcessorFactory;
        _logger = logger;
    }

    public async Task<(bool Success, string Message)> ImportFileAsync(string filePath, string fileType)
    {
        try
        {
            _logger.LogInformation("Iniciando importación de archivo: {FilePath} de tipo: {FileType}", 
                filePath, fileType);
            var fileName = Path.GetFileName(filePath);

            switch (fileType.ToLower())
            {
                case "binancep2p":
                    _logger.LogDebug("Obteniendo procesador para archivo P2P: {FileName}", fileName);
                    var p2pProcessor = _fileProcessorFactory.GetProcessor<BinanceP2P>(fileType);
                    
                    _logger.LogDebug("Iniciando procesamiento de archivo P2P: {FileName}", fileName);
                    var p2pTrades = await p2pProcessor.ProcessAsync(filePath);
                    var p2pTradesList = p2pTrades.ToList();
                    
                    _logger.LogInformation("Se obtuvieron {Count} registros del archivo P2P: {FileName}",
                        p2pTradesList.Count, fileName);
                    
                    _logger.LogDebug("Guardando {Count} registros P2P en base de datos", p2pTradesList.Count);
                    var p2pResult = await _p2pRepository.AddRangeAsync(p2pTradesList);
                    
                    var resultMessage = $"Operaciones P2P importadas exitosamente: {p2pTradesList.Count} registros";
                    _logger.LogInformation("Resultado importación P2P: {Success}, {Message}", 
                        p2pResult, resultMessage);
                    
                    return (p2pResult, resultMessage);

                case "binanceorderspot":
                    _logger.LogDebug("Obteniendo procesador para archivo Spot: {FileName}", fileName);
                    var spotProcessor = _fileProcessorFactory.GetProcessor<BinanceSpotHistory>(fileType);
                    
                    _logger.LogDebug("Iniciando procesamiento de archivo Spot: {FileName}", fileName);
                    var spotTrades = await spotProcessor.ProcessAsync(filePath);
                    var spotTradesList = spotTrades.ToList();
                    
                    _logger.LogInformation("Se obtuvieron {Count} registros del archivo Spot: {FileName}",
                        spotTradesList.Count, fileName);
                    
                    _logger.LogDebug("Guardando {Count} registros Spot en base de datos", spotTradesList.Count);
                    var spotResult = await _spotRepository.AddRangeAsync(spotTradesList);
                    
                    var spotResultMessage = $"Operaciones Spot importadas exitosamente: {spotTradesList.Count} registros";
                    _logger.LogInformation("Resultado importación Spot: {Success}, {Message}", 
                        spotResult, spotResultMessage);
                    
                    return (spotResult, spotResultMessage);

                default:
                    var errorMessage = $"Tipo de archivo no soportado: {fileType}";
                    _logger.LogWarning("Error de tipo de archivo: {ErrorMessage}", errorMessage);
                    return (false, errorMessage);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error importando archivo: {FilePath}. Error: {ErrorMessage}, StackTrace: {StackTrace}", 
                filePath, ex.Message, ex.StackTrace);
            return (false, $"Error importando archivo: {ex.Message}");
        }
    }

    public async Task<(bool Success, string Message)> ProcessDirectoryAsync(string directoryPath, string fileType)
    {
        try
        {
            _logger.LogInformation("Procesando directorio: {DirectoryPath} para tipo de archivo: {FileType}", 
                directoryPath, fileType);

            var extension = fileType.ToLower() == "binancep2p" ? "*.csv" : "*.xlsx";
            var files = Directory.GetFiles(directoryPath, extension);
            
            _logger.LogInformation("Se encontraron {FileCount} archivos de tipo {Extension} en {DirectoryPath}", 
                files.Length, extension, directoryPath);

            if (files.Length == 0)
            {
                var noFilesMessage = $"No se encontraron archivos {extension} en el directorio";
                _logger.LogWarning(noFilesMessage);
                return (true, noFilesMessage);
            }

            // Configuración de paralelismo ajustable según la capacidad del sistema
            var maxDegreeOfParallelism = Math.Max(1, Environment.ProcessorCount - 1);
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxDegreeOfParallelism };

            _logger.LogInformation("Procesando {FileCount} archivos con {ThreadCount} hilos en paralelo", 
                files.Length, maxDegreeOfParallelism);

            // Contadores atómicos para estadísticas
            var successCount = 0;
            var failCount = 0;
            var startTime = DateTime.Now;

            // Procesamiento paralelo de archivos
            await Parallel.ForEachAsync(files, parallelOptions, async (file, token) =>
            {
                _logger.LogDebug("Iniciando procesamiento paralelo de archivo: {FileName}", Path.GetFileName(file));
                var result = await ImportFileAsync(file, fileType);
                
                if (result.Success)
                {
                    _logger.LogDebug("Archivo {FileName} procesado exitosamente", Path.GetFileName(file));
                    Interlocked.Increment(ref successCount);
                }
                else
                {
                    _logger.LogWarning("Falló el procesamiento de archivo {FileName}: {Message}", 
                        Path.GetFileName(file), result.Message);
                    Interlocked.Increment(ref failCount);
                }
            });

            var totalTime = DateTime.Now - startTime;
            var resultMessage = $"Procesados {successCount} archivos exitosamente, {failCount} archivos fallidos en {totalTime.TotalSeconds:0.00} segundos";
            
            _logger.LogInformation("Finalizado procesamiento de directorio: {DirectoryPath}. {ResultMessage}", 
                directoryPath, resultMessage);

            return (failCount == 0, resultMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error procesando directorio: {DirectoryPath}. Error: {ErrorMessage}, StackTrace: {StackTrace}", 
                directoryPath, ex.Message, ex.StackTrace);
            return (false, $"Error procesando directorio: {ex.Message}");
        }
    }
}