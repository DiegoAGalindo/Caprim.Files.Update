using CsvHelper.Configuration;
using Caprim.Files.Update.Domain.Models;

namespace Caprim.Files.Update.Infrastructure.Adapters.FileProcessing;

public sealed class BinanceP2PMap : ClassMap<BinanceP2P>
{
    public BinanceP2PMap()
    {
        Map(m => m.OrderNumber).Name("Order Number");
        Map(m => m.OrderType).Name("Order Type");
        Map(m => m.AssetType).Name("Asset Type");
        Map(m => m.FiatType).Name("Fiat Type");
        Map(m => m.TotalPrice).Name("Total Price");
        Map(m => m.Price).Name("Price");
        Map(m => m.Quantity).Name("Quantity");
        Map(m => m.MakerFee).Name("Maker Fee");
        Map(m => m.Couterparty).Name("Couterparty");
        Map(m => m.Status).Name("Status");
        Map(m => m.CreatedTime).Name("Created Time");
    }
}