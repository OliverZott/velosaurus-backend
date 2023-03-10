using Microsoft.EntityFrameworkCore;
using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Services;

public class TourDatabaseService
{
    private readonly TourDbContext _tourDbContext;
    private readonly ILogger<TourDatabaseService> _logger;

    public TourDatabaseService(TourDbContext tourDbContext, ILogger<TourDatabaseService> logger,
        IConfiguration configuration)
    {
        _tourDbContext = tourDbContext;
        _logger = logger;
        _logger.LogInformation("TourDatabaseService instantiated...");
    }

    public async Task<Tour> CreateTour(Tour tour)
    {
        await _tourDbContext.AddAsync(tour);
        return tour;
    }

    public async Task<List<Tour>> GetAllAsync()
    {
        return await _tourDbContext.Set<Tour>().ToListAsync();
    }

    public async Task<Tour> GetAsync(int? id)
    {
        var result = await _tourDbContext.Set<Tour>().FindAsync(id);
        if (result is null)
        {
            throw new KeyNotFoundException($"No Tour with id: {id} found!");
        }

        return result;
    }
}

