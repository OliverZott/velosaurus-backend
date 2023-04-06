using Microsoft.EntityFrameworkCore;
using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Services;

public class TourDatabaseService
{
    private readonly TourDbContext _context;
    private readonly ILogger<TourDatabaseService> _logger;

    public TourDatabaseService(TourDbContext context, ILogger<TourDatabaseService> logger)
    {
        _context = context;
        _logger = logger;
        _logger.LogInformation("TourDatabaseService instantiated...");
    }

    public async Task<Tour> AddTourAsync(Tour tour)
    {
        await _context.AddAsync(tour);
        await _context.SaveChangesAsync();
        return tour;
    }

    public async Task<List<Tour>> GetToursAsync()
    {
        return await _context.Set<Tour>().ToListAsync();
    }

    public async Task<Tour?> GetTourAsync(int id)
    {
        var result = await _context.Set<Tour>().FindAsync(id);
        if (result is null)
        {
            _logger.LogError("No Tour with id: {} found in database", id);
            throw new KeyNotFoundException($"No Tour with id: {id} found!");
        }

        return result;
    }
}