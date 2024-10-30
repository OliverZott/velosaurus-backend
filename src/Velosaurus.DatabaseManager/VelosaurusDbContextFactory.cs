using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Velosaurus.DatabaseManager;

public class VelosaurusDbContextFactory : IDesignTimeDbContextFactory<VelosaurusDbContext>
{
    public VelosaurusDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<VelosaurusDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost; Database=velosaurus; Port=5432; User Id=postgres; Password=password");

        return new VelosaurusDbContext(optionsBuilder.Options);
    }
}