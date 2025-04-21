using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Caprim.Files.Update.Domain.Models;

namespace Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;

public class CsvAdapter
{
    public async Task<IEnumerable<BinanceP2P>> ReadBinanceP2PAsync(string filePath)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            HeaderValidated = null
        };

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, config);
        
        csv.Context.RegisterClassMap<BinanceP2PMap>();
        return await Task.FromResult(csv.GetRecords<BinanceP2P>().ToList());
    }
} 