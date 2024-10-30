using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly VelosaurusDbContext _velosaurusDbContext;

    public UnitOfWork(VelosaurusDbContext velosaurusDbContext,
        IGenericRepository<Activity>? activity,
        IGenericRepository<Location>? location)
    {
        _velosaurusDbContext = velosaurusDbContext;
        Activity = activity ?? throw new ArgumentNullException(nameof(activity));
        Location = location ?? throw new ArgumentNullException(nameof(location));
    }

    public IGenericRepository<Activity> Activity { get; }

    public IGenericRepository<Location> Location { get; }

    public void Dispose()
    {
        _velosaurusDbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<int> Complete()
    {
        return await _velosaurusDbContext.SaveChangesAsync();
    }
}