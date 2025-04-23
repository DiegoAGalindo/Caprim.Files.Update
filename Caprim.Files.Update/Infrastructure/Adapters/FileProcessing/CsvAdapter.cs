using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Caprim.Files.Update.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;

public class CsvAdapter
{
    private readonly ILogger<CsvAdapter> _logger;

    public CsvAdapter(ILogger<CsvAdapter> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<BinanceP2P>> ReadBinanceP2PAsync(string filePath)
    {
        _logger.LogInformation("Iniciando lectura del archivo P2P: {FilePath}", filePath);

        try
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null,
                BadDataFound = context =>
                {
                    _logger.LogWarning("Datos incorrectos encontrados: {RawRecord}", 
                        context.RawRecord);
                }
            };

            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, config);
            
            csv.Context.RegisterClassMap<BinanceP2PMap>();

            var records = new List<BinanceP2P>();
            var recordNumber = 0;

            await foreach (var record in csv.GetRecordsAsync<BinanceP2P>())
            {
                recordNumber++;
                try
                {
                    records.Add(record);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error procesando el registro {RecordNumber} en archivo {FilePath}: {ErrorMessage}", 
                        recordNumber, Path.GetFileName(filePath), ex.Message);
                }
            }

            _logger.LogInformation("Lectura completada de archivo {FileName}. {RecordCount} registros procesados", 
                Path.GetFileName(filePath), records.Count);
            return records;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error crítico al leer el archivo CSV {FilePath}: {ErrorMessage}", 
                Path.GetFileName(filePath), ex.Message);
            throw;
        }
    }
    
    public async Task<IEnumerable<BinanceP2P>> ReadBinanceP2PBatchAsync(string filePath, int batchSize = 1000)
    {
        _logger.LogInformation("Iniciando lectura por lotes del archivo P2P: {FilePath}, tamaño de lote: {BatchSize}", 
            filePath, batchSize);

        try
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null,
                BadDataFound = context => 
                    _logger.LogWarning("Datos incorrectos encontrados: {RawRecord}", 
                        context.RawRecord)
            };

            using var reader = new StreamReader(filePath, new FileStreamOptions
            {
                BufferSize = 4096,
                Mode = FileMode.Open,
                Access = FileAccess.Read,
                Share = FileShare.Read
            });
            
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<BinanceP2PMap>();

            var records = new List<BinanceP2P>();
            int recordCount = 0;

            await foreach (var record in csv.GetRecordsAsync<BinanceP2P>())
            {
                try
                {
                    records.Add(record);
                    recordCount++;
                    
                    if (recordCount % 1000 == 0)
                    {
                        _logger.LogDebug("Procesados {Count} registros del archivo {FileName}", 
                            recordCount, Path.GetFileName(filePath));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error procesando registro #{RecordNumber} en archivo {FilePath}: {ErrorMessage}", 
                        recordCount, Path.GetFileName(filePath), ex.Message);
                }
            }

            _logger.LogInformation("Lectura por lotes completada para archivo {FileName}. {RecordCount} registros procesados", 
                Path.GetFileName(filePath), recordCount);
            return records;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error crítico al leer el archivo CSV por lotes {FilePath}: {ErrorMessage}", 
                Path.GetFileName(filePath), ex.Message);
            throw;
        }
    }
} 