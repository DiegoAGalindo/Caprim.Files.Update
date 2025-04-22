using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CsvHelper.Configuration.Attributes;

namespace Caprim.Files.Update.Domain.Models;

public class BinanceP2P
{
    [Key]
    [Name("OrderNumber")]
    public string? OrderNumber { get; set; } = string.Empty;

    [Name("OrderType")]
    public string? OrderType { get; set; }

    [Name("AssetType")]
    public string? AssetType { get; set; }

    [Name("FiatType")]
    public string? FiatType { get; set; }

    [Name("TotalPrice")]
    [Column(TypeName = "decimal(15,2)")]
    public decimal? TotalPrice { get; set; }

    [Name("Price")]
    [Column(TypeName = "decimal(15,2)")]
    public decimal? Price { get; set; }

    [Name("Quantity")]
    [Column(TypeName = "decimal(15,2)")]
    public decimal? Quantity { get; set; }

    [Name("MakerFee")]
    [Column(TypeName = "decimal(15,2)")]
    public decimal? MakerFee { get; set; }

    [Name("Couterparty")]
    public string? Couterparty { get; set; }

    [Name("Status")]
    public string? Status { get; set; }

    [Name("CreatedTime")]
    public DateTime? CreatedTime { get; set; }
}