using ClosedXML.Excel;
using Caprim.Files.Update.Domain.Models;

namespace Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;

public class ExcelAdapter
{
    public async Task<IEnumerable<BinanceSpotHistory>> ReadBinanceSpotHistoryAsync(string filePath)
    {
        var trades = new List<BinanceSpotHistory>();

        using var workbook = new XLWorkbook(filePath);
        var worksheet = workbook.Worksheet(1);
        var rows = worksheet.RowsUsed().Skip(1); // Skip header row

        foreach (var row in rows)
        {
            var trade = new BinanceSpotHistory
            {
                DateUtc = row.Cell(1).GetDateTime(),
                OrderNo = row.Cell(2).GetString(),
                Pair = row.Cell(3).GetString(),
                BaseAsset = row.Cell(4).GetString(),
                QuoteAsset = row.Cell(5).GetString(),
                Type = row.Cell(6).GetString(),
                OrderPrice = decimal.Parse(row.Cell(7).GetString()),
                OrderAmount = decimal.Parse(row.Cell(8).GetString()),
                AvgTradingPrice = decimal.Parse(row.Cell(9).GetString()),
                Filled = decimal.Parse(row.Cell(10).GetString()),
                Total = decimal.Parse(row.Cell(11).GetString()),
                Status = row.Cell(12).GetString()
            };

            trades.Add(trade);
        }

        return await Task.FromResult(trades);
    }
} 