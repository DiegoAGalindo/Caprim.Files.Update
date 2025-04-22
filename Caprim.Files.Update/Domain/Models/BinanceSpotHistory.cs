namespace Caprim.Files.Update.Domain.Models;

public class BinanceSpotHistory
{
    public DateTime DateUtc { get; set; }
    public string OrderNo { get; set; } = string.Empty;
    public string? Pair { get; set; }
    public string? BaseAsset { get; set; }
    public string? QuoteAsset { get; set; }
    public string? Type { get; set; }
    public decimal? OrderPrice { get; set; }
    public decimal? OrderAmount { get; set; }
    public decimal? AvgTradingPrice { get; set; }
    public decimal? Filled { get; set; }
    public decimal? Total { get; set; }
    public string? Status { get; set; }
}