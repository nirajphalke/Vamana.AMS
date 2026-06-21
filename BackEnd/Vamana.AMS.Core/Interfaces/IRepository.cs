using System.Linq.Expressions;

namespace Vamana.AMS.Core.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> ListAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
