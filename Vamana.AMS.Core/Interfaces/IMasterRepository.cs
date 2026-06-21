namespace Vamana.AMS.Core.Interfaces;
public interface IMasterRepository<T> where T : class
{
    Task<IEnumerable<object>> GetLookupAsync(Func<T, object> selector);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(object key);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveAsync();
}