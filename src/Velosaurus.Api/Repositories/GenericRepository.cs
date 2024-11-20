using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Velosaurus.Core.Exceptions;
using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly VelosaurusDbContext _context;


    public GenericRepository(VelosaurusDbContext context)
    {
        _context = context;
    }


    public async Task<T> GetAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (var includeProperty in includeProperties) query = query.Include(includeProperty);
        var entity = await query.FirstOrDefaultAsync(entity => entity.Id == id);
        return entity ?? throw new ItemNotFoundException($"{typeof(T)}", id);
    }

    public async Task<(List<T>, int activitiesCount)> GetAllPaginatedAsync(int pageNumber, int pageSize)
    {
        var activitiesCount = await _context.Set<T>().CountAsync();

        var activities = await _context.Set<T>()
            .OrderByDescending(a => a.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (activities, activitiesCount);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().OrderByDescending(a => a.Id).ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        // Set<T> is for set-oriented operations and querying.
        //_context.Set<T>().Update(entity);  

        // Entry<T>() provides detailed control over individual entity states.
        //_context.Entry<T>(entity).State = EntityState.Modified;  

        //Update<T>() simplifies the process of updating an entire entity and also sets entity state.
        _context.Update(entity); // also sets entity state to modified
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id) ?? throw new ItemNotFoundException(typeof(T).Name, id);

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}