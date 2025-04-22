using Caprim.Files.Update.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Caprim.Files.Update.Infrastructure.Adapters.Persistence;

public class MariaDbContext : DbContext
{
    public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options)
    {
    }

    public DbSet<BinanceP2P> BinanceP2P { get; set; }
    public DbSet<BinanceSpotHistory> BinanceSpotHistory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BinanceP2P>(entity =>
        {
            entity.ToTable("BinanceP2P");
            entity.HasKey(e => e.OrderNumber);
            entity.HasIndex(e => e.CreatedTime);
        });

        modelBuilder.Entity<BinanceSpotHistory>(entity =>
        {
            entity.ToTable("BinanceSpotHistory");
            entity.HasKey(e => e.OrderNo);
            entity.HasIndex(e => e.DateUtc);
        });
    }
}