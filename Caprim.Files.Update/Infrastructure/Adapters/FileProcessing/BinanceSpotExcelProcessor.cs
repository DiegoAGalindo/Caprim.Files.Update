using Caprim.Files.Update.Core.Strategy;
using Caprim.Files.Update.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;

public class BinanceSpotExcelProcessor : IFileProcessor<BinanceSpotHistory>
{
    private readonly ExcelAdapter _excelAdapter;
    private readonly ILogger<BinanceSpotExcelProcessor> _logger;

    public BinanceSpotExcelProcessor(ExcelAdapter excelAdapter, ILogger<BinanceSpotExcelProcessor> logger)
    {
        _excelAdapter = excelAdapter;
        _logger = logger;
    }

    public async Task<IEnumerable<BinanceSpotHistory>> ProcessAsync(string filePath)
    {
        _logger.LogInformation("Procesando archivo Spot Excel: {FilePath}", filePath);

        try
        {
            var records = await _excelAdapter.ReadBinanceSpotHistoryAsync(filePath);
            _logger.LogInformation("Procesados registros del archivo Spot");
            return records;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error procesando archivo Spot Excel: {FilePath}", filePath);
            throw;
        }
    }
}