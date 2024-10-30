using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Velosaurus.Core.Exceptions;
using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Repositories;

public class GenericRepository<T>(VelosaurusDbContext context) : IGenericRepository<T>
    where T : class, IEntity
{
    public async Task<T?> GetAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = context.Set<T>();

        foreach (var includeProperty in includeProperties) query = query.Include(includeProperty);
        var entity = await query.FirstOrDefaultAsync(entity => entity.Id == id);
        return entity;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        context.Update(entity); // also sets entity state to modified
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);

        if (entity == null) throw new ItemNotFoundException(typeof(T).Name, id);

        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
}