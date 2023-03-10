namespace Velosaurus.Api.Models;

public class TourDatabaseSettings
{
    public string DbConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string TourCollectionName { get; set; } = null!;
}