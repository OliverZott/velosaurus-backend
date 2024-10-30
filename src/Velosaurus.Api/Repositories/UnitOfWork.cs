using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Repositories;

public class UnitOfWork(
    VelosaurusDbContext velosaurusDbContext,
    IGenericRepository<Tour>? tour,
    IGenericRepository<Mountain>? mountain
) : IUnitOfWork
{
    public IGenericRepository<Tour> Tour { get; } = tour ?? throw new ArgumentNullException(nameof(tour));

    public IGenericRepository<Mountain> Mountain { get; } =
        mountain ?? throw new ArgumentNullException(nameof(mountain));

    public void Dispose()
    {
        velosaurusDbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<int> Complete()
    {
        return await velosaurusDbContext.SaveChangesAsync();
    }
}