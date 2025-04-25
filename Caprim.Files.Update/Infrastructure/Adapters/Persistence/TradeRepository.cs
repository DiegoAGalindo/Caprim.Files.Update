using Caprim.Files.Update.Core.Ports.Output;
using Caprim.Files.Update.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Caprim.Files.Update.Infrastructure.Adapters.Persistence;

public class TradeRepository<T> : ITradeRepository<T> where T : class
{
    private readonly MariaDbContext _context;
    private readonly DbSet<T> _dbSet;
    private readonly ILogger<TradeRepository<T>> _logger;

    public TradeRepository(MariaDbContext context, ILogger<TradeRepository<T>> logger)
    {
        _context = context;
        _dbSet = context.Set<T>();
        _logger = logger;
    }

    public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
    {
        try
        {
            var entitiesList = entities.ToList();
            if (!entitiesList.Any())
            {
                _logger.LogInformation("No hay registros para agregar de tipo {EntityType}", typeof(T).Name);
                return true;
            }

            _logger.LogInformation("Intentando agregar {Count} registros de tipo {EntityType}",
                entitiesList.Count, typeof(T).Name);

            // Obtener el nombre de la propiedad clave primaria según el tipo de entidad
            string keyPropertyName;
            if (typeof(T) == typeof(BinanceP2P))
            {
                keyPropertyName = nameof(BinanceP2P.OrderNumber);
                _logger.LogDebug("Clave primaria para BinanceP2P: {KeyName}", keyPropertyName);
            }
            else if (typeof(T) == typeof(BinanceSpotHistory))
            {
                keyPropertyName = nameof(BinanceSpotHistory.OrderNo);
                _logger.LogDebug("Clave primaria para BinanceSpotHistory: {KeyName}", keyPropertyName);
            }
            else
            {
                _logger.LogWarning("Tipo de entidad no reconocido: {EntityType}", typeof(T).Name);
                return false;
            }

            // Obtener los valores de clave primaria de las entidades a insertar
            var propertyInfo = typeof(T).GetProperty(keyPropertyName);
            if (propertyInfo == null)
            {
                _logger.LogError("No se encontró la propiedad {PropertyName} en la entidad {EntityType}",
                    keyPropertyName, typeof(T).Name);
                return false;
            }

            var keysToAdd = entitiesList
                .Select(e => propertyInfo.GetValue(e)?.ToString())
                .Where(k => !string.IsNullOrEmpty(k))
                .ToHashSet();

            // Filtrar entidades para evitar duplicados
            if (keysToAdd.Count > 0)
            {
                // Comprobar qué registros ya existen en la base de datos
                var existingEntities = await _dbSet
                    .AsNoTracking()
                    .ToListAsync();

                var existingKeys = existingEntities
                    .Select(e => propertyInfo.GetValue(e)?.ToString())
                    .Where(k => !string.IsNullOrEmpty(k))
                    .ToHashSet();

                var newEntities = entitiesList
                    .Where(e => !existingKeys.Contains(propertyInfo.GetValue(e)?.ToString()))
                    .ToList();

                _logger.LogInformation("Se encontraron {ExistingCount} registros existentes, se agregarán {NewCount} nuevos registros",
                    existingKeys.Count, newEntities.Count);

                if (newEntities.Count > 0)
                {
                    // Agregar los nuevos registros en lotes
                    var batchSize = 100;
                    for (int i = 0; i < newEntities.Count; i += batchSize)
                    {
                        var batch = newEntities.Skip(i).Take(batchSize).ToList();
                        await _dbSet.AddRangeAsync(batch);
                        await _context.SaveChangesAsync();
                        _logger.LogDebug("Guardado lote {CurrentBatch}/{TotalBatches} con {BatchSize} registros",
                            (i / batchSize) + 1, (newEntities.Count / batchSize) + 1, batch.Count);
                    }
                }

                return true;
            }

            return true;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, "Error de base de datos al agregar registros de tipo {EntityType}. Error: {Message}",
                typeof(T).Name, ex.InnerException?.Message ?? ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error general al agregar registros de tipo {EntityType}. Error: {Message}",
                typeof(T).Name, ex.Message);
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