using Microsoft.EntityFrameworkCore;
using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Services;

public class TourDatabaseService
{
    private readonly VelosaurusDbContext _context;

    public TourDatabaseService(VelosaurusDbContext context, ILogger<TourDatabaseService> logger)
    {
        _context = context;
        logger.LogInformation("TourDatabaseService instantiated...");
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
        var tour = await _context.Set<Tour>().FindAsync(id);
        return tour;
    }
}