using Caprim.Files.Update.Core.Ports.Output;
using Microsoft.EntityFrameworkCore;

namespace Caprim.Files.Update.Infrastructure.Adapters.Persistence;

public class TradeRepository<T> : ITradeRepository<T> where T : class
{
    private readonly MariaDbContext _context;
    private readonly DbSet<T> _dbSet;

    public TradeRepository(MariaDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            // Log the exception (if logging is set up)
            Console.WriteLine($"Error adding range: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> ExistsAsync(string orderNumber)
    {
        var item = await _dbSet.FindAsync(orderNumber);
        return item != null;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
}