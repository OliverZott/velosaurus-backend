﻿using Microsoft.EntityFrameworkCore;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.DatabaseManager;

public class TourDbContext : DbContext
{
    public TourDbContext(DbContextOptions contextOptions) : base(contextOptions) { }

    public DbSet<Tour>? Tours { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tour>().HasKey(t => new { t.Id });
    }
}