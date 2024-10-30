using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Activity> Activity { get; }
    IGenericRepository<Location> Location { get; }
}