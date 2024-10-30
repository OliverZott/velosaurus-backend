using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Velosaurus.Core.Exceptions;
using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
{
    private readonly VelosaurusDbContext _context;

    public GenericRepository(VelosaurusDbContext context)
    {
        _context = context;
    }

    // TODO get locations/activities respectively for parent
    public async Task<T?> GetAsync(int id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _context.Set<T>();

        foreach (var includeProperty in includeProperties) query = query.Include(includeProperty);
        var entity = await query.FirstOrDefaultAsync(entity => entity.Id == id);
        return entity;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Update(entity); // also sets entity state to modified
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);

        if (entity == null) throw new ItemNotFoundException(typeof(T).Name, id);

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}