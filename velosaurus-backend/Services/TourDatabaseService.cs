using Microsoft.Extensions.Options;
using MongoDB.Driver;
using velosaurus_backend.Models;

namespace velosaurus_backend.Services;

public class TourDatabaseService
{
    private readonly IMongoCollection<Tour> _tourCollection;
    private readonly ILogger<TourDatabaseService> _logger;

    public TourDatabaseService(IOptions<TourDatabaseSettings> options, ILogger<TourDatabaseService> logger, IConfiguration configuration)
    {
        //local
        //var mongoClient = new MongoClient(configuration["MongoDb:url"]);

        var mongoClient = new MongoClient(options.Value.DbConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
        _tourCollection = mongoDatabase.GetCollection<Tour>(options.Value.TourCollectionName);
        _logger = logger;
        _logger.LogInformation("TourDatabaseService instantiated...");
    }

    public Task CreateTour(Tour tour)
    {
        return _tourCollection.InsertOneAsync(tour);
    }

    public async Task<List<Tour>> GetAll()
    {
        var results = await _tourCollection.FindAsync(_ => true);
        return results.ToList();
    }

    // Alternative variant
    public async Task<List<Tour>> GetAsync() =>
        await _tourCollection.Find(_ => true).ToListAsync();

    public async Task<Tour> GetById(string id) =>
       await _tourCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

}

