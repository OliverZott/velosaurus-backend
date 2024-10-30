using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Tour> Tour { get; }
    IGenericRepository<Mountain> Mountain { get; }
}