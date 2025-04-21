namespace Caprim.Files.Update.Domain.Models;

public class BinanceP2P
{
    public string OrderNumber { get; set; } = string.Empty;
    public string? OrderType { get; set; }
    public string? AssetType { get; set; }
    public string? FiatType { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public decimal MakerFee { get; set; }
    public string? Couterparty { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedTime { get; set; }
} 