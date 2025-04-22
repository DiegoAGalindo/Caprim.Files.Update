using Caprim.Files.Update.Core.Ports.Input;
using Caprim.Files.Update.Core.Ports.Output;
using Caprim.Files.Update.Domain.Models;
using Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update.Core.UseCases;

public class FileImportUseCase : IFileImportUseCase
{
    private readonly ITradeRepository<BinanceP2P> _p2pRepository;
    private readonly ITradeRepository<BinanceSpotHistory> _spotRepository;
    private readonly CsvAdapter _csvAdapter;
    private readonly ExcelAdapter _excelAdapter;
    private readonly ILogger<FileImportUseCase> _logger;

    public FileImportUseCase(
        ITradeRepository<BinanceP2P> p2pRepository,
        ITradeRepository<BinanceSpotHistory> spotRepository,
        CsvAdapter csvAdapter,
        ExcelAdapter excelAdapter,
        ILogger<FileImportUseCase> logger)
    {
        _p2pRepository = p2pRepository;
        _spotRepository = spotRepository;
        _csvAdapter = csvAdapter;
        _excelAdapter = excelAdapter;
        _logger = logger;
    }

    public async Task<(bool Success, string Message)> ImportFileAsync(string filePath, string fileType)
    {
        try
        {
            _logger.LogInformation("Starting import of file: {FilePath} of type: {FileType}", filePath, fileType);

            switch (fileType.ToLower())
            {
                case "binancep2p":
                    var p2pTrades = await _csvAdapter.ReadBinanceP2PAsync(filePath);
                    p2pTrades = p2pTrades.Where(x => x.OrderType?.Contains("Buy") == true);
                    var p2pResult = await _p2pRepository.AddRangeAsync(p2pTrades);
                    return (p2pResult, "P2P trades imported successfully");

                case "binanceorderspot":
                    var spotTrades = await _excelAdapter.ReadBinanceSpotHistoryAsync(filePath);
                    var spotResult = await _spotRepository.AddRangeAsync(spotTrades);
                    return (spotResult, "Spot trades imported successfully");

                default:
                    return (false, $"Unsupported file type: {fileType}");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error importing file: {FilePath}", filePath);
            return (false, $"Error importing file: {ex.Message}");
        }
    }

    public async Task<(bool Success, string Message)> ProcessDirectoryAsync(string directoryPath, string fileType)
    {
        try
        {
            _logger.LogInformation("Processing directory: {DirectoryPath} for file type: {FileType}", directoryPath, fileType);

            var extension = fileType.ToLower() == "binancep2p" ? "*.csv" : "*.xlsx";
            var files = Directory.GetFiles(directoryPath, extension);

            var successCount = 0;
            var failCount = 0;

            foreach (var file in files)
            {
                var result = await ImportFileAsync(file, fileType);
                if (result.Success)
                    successCount++;
                else
                    failCount++;
            }

            return (failCount == 0, $"Processed {successCount} files successfully, {failCount} files failed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing directory: {DirectoryPath}", directoryPath);
            return (false, $"Error processing directory: {ex.Message}");
        }
    }
}