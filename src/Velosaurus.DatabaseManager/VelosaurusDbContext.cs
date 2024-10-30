using Microsoft.EntityFrameworkCore;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.DatabaseManager;

public class VelosaurusDbContext(DbContextOptions contextOptions) : DbContext(contextOptions)
{
    public DbSet<Activity>? Activities { get; set; }
    public DbSet<Location>? Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>().HasKey(t => new { t.Id });
        modelBuilder.Entity<Location>().HasKey(t => new { t.Id });
    }
}