using Microsoft.EntityFrameworkCore;
using Velosaurus.DatabaseManager;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Services;

public class ActivityDatabaseService
{
    private readonly VelosaurusDbContext _context;

    public ActivityDatabaseService(VelosaurusDbContext context, ILogger<ActivityDatabaseService> logger)
    {
        _context = context;
        logger.LogInformation("ActivityDatabaseService instantiated...");
    }

    public async Task<Activity> AddActivityAsync(Activity activity)
    {
        await _context.AddAsync(activity);
        await _context.SaveChangesAsync();
        return activity;
    }

    public async Task<List<Activity>> GetActivitiesAsync()
    {
        return await _context.Set<Activity>().ToListAsync();
    }

    public async Task<Activity?> GetActivityAsync(int id)
    {
        var activity = await _context.Set<Activity>().FindAsync(id);
        return activity;
    }
}