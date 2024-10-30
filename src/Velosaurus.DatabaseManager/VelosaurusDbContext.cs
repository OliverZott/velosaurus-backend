using Microsoft.EntityFrameworkCore;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.DatabaseManager;

public class VelosaurusDbContext(DbContextOptions contextOptions) : DbContext(contextOptions)
{
    public DbSet<Tour>? Tours { get; set; }
    public DbSet<Mountain>? Mountains { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>().HasKey(t => new { t.Id });
        modelBuilder.Entity<Mountain>().HasKey(t => new { t.Id });
    }
}