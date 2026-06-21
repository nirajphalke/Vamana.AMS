using Microsoft.EntityFrameworkCore;
using Vamana.AMS.Core.Interfaces;

namespace Vamana.AMS.Infrastructure.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _set;
    public GenericRepository(DbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    public virtual async Task AddAsync(T entity) => await _set.AddAsync(entity);
    public virtual async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);
    public virtual async Task<IEnumerable<T>> ListAsync() => await _set.ToListAsync();
    public void Remove(T entity) => _set.Remove(entity);
    public void Update(T entity) => _set.Update(entity);
    public async Task<IEnumerable<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        => await _set.Where(predicate).ToListAsync();
}
