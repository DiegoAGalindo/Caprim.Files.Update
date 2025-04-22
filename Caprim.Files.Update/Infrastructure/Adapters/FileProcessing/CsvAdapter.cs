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
                    _logger.LogWarning("Datos incorrectos encontrados: {RawRecord}", context.RawRecord);
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
                    _logger.LogError(ex, "Error procesando el registro {RecordNumber}", recordNumber);
                }
            }

            _logger.LogInformation("Lectura completada. {RecordCount} registros procesados", records.Count);
            return records;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al leer el archivo CSV: {FilePath}", filePath);
            throw;
        }
    }
} 