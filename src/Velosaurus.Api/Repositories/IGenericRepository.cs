using System.Linq.Expressions;

namespace Velosaurus.Api.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetAsync(int id, params Expression<Func<T, object>>[] includeProperties);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(int id);
}