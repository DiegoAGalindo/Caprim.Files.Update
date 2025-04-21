using Caprim.Files.Update.Domain.Models;

namespace Caprim.Files.Update.Core.Ports.Output;

public interface ITradeRepository<T> where T : class
{
    Task<bool> AddRangeAsync(IEnumerable<T> entities);

    Task<bool> ExistsAsync(string id);

    Task<IEnumerable<T>> GetAllAsync();
}