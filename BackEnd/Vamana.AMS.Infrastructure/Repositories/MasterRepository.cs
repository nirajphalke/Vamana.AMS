using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Vamana.AMS.Core.Interfaces;
using Vamana.AMS.Infrastructure.Data;

namespace Vamana.AMS.Infrastructure.Repositories;

public class MasterRepository<T> : IMasterRepository<T> where T : class
{
    private readonly MasterDbContext _context;
    private readonly DbSet<T> _dbSet;
    private readonly IMemoryCache _cache;
    private readonly string _cacheKey;

    public MasterRepository(MasterDbContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
        _dbSet = _context.Set<T>();
        _cacheKey = $"Master:{typeof(T).Name}";
    }

    public async Task<IEnumerable<object>> GetLookupAsync(Func<T, object> selector, bool forceRefresh = false)
    {
        var items = await GetAllAsync(forceRefresh);
        return items.Select(selector);
    }

    //public async Task<IEnumerable<T>> GetAllAsync()
    //{
    //    // Return from cache if exists
    //    if (_cache.TryGetValue(_cacheKey, out IEnumerable<T>? cachedData))
    //    {
    //        return cachedData!;
    //    }

    //    IQueryable<T> query = _dbSet.AsQueryable();

    //    var entityType = _context.Model.FindEntityType(typeof(T));
    //    if (entityType != null)
    //    {
    //        var navigationNames = entityType.GetNavigations().Select(n => n.Name);
    //        foreach (var navigation in navigationNames)
    //        {
    //            query = query.Include(navigation);
    //        }
    //    }

    //    var result = await query.ToListAsync();

    //    // Set into cache with expiration
    //    _cache.Set(_cacheKey, result, new MemoryCacheEntryOptions
    //    {
    //        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
    //        SlidingExpiration = TimeSpan.FromMinutes(5)     // to be configured based on usage patterns
    //    });

    //    return result;
    //}

    public async Task<IEnumerable<T>> GetAllAsync(bool forceRefresh = false)
    {
        // Return from cache if it exists AND we are NOT forcing a refresh
        if (!forceRefresh && _cache.TryGetValue(_cacheKey, out IEnumerable<T>? cachedData))
        {
            return cachedData!;
        }

        IQueryable<T> query = _dbSet.AsQueryable();

        var entityType = _context.Model.FindEntityType(typeof(T));
        if (entityType != null)
        {
            var navigationNames = entityType.GetNavigations().Select(n => n.Name);
            foreach (var navigation in navigationNames)
            {
                query = query.Include(navigation);
            }
        }

        var result = await query.ToListAsync();

        // Set into cache (this will overwrite the old cache if forceRefresh was true)
        _cache.Set(_cacheKey, result, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            SlidingExpiration = TimeSpan.FromMinutes(5)
        });

        return result;
    }

    public async Task<T> GetByIdAsync(object key)
    {
        var entity = await _dbSet.FindAsync(key);
        if (entity == null)
        {
            throw new InvalidOperationException($"Entity of type {typeof(T).Name} with key '{key}' was not found.");
        }
        return entity;
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    private void InvalidateCache()
    {
        _cache.Remove(_cacheKey);
    }
}