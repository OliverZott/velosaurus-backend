using System.Linq.Expressions;

namespace Velosaurus.Api.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetAsync(int id, params Expression<Func<T, object>>[] includeProperties);
    Task<(List<T>, int activitiesCount)> GetAllAsync(int pageNumber, int pageSize);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}