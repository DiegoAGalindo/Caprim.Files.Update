using Caprim.Files.Update.Core.Strategy;
using Caprim.Files.Update.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;

public class BinanceP2PCsvProcessor : IFileProcessor<BinanceP2P>
{
    private readonly CsvAdapter _csvAdapter;
    private readonly ILogger<BinanceP2PCsvProcessor> _logger;

    public BinanceP2PCsvProcessor(CsvAdapter csvAdapter, ILogger<BinanceP2PCsvProcessor> logger)
    {
        _csvAdapter = csvAdapter;
        _logger = logger;
    }

    public async Task<IEnumerable<BinanceP2P>> ProcessAsync(string filePath)
    {
        _logger.LogInformation("Procesando archivo P2P CSV: {FilePath}", filePath);

        try
        {
            var records = await _csvAdapter.ReadBinanceP2PBatchAsync(filePath);
            _logger.LogInformation("Procesados registros del archivo P2P");

            // Filtrar solo las operaciones de compra
            return records.Where(x => x.OrderType?.Contains("Buy") == true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error procesando archivo P2P CSV: {FilePath}", filePath);
            throw;
        }
    }
}