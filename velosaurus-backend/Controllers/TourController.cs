using Microsoft.AspNetCore.Mvc;
using velosaurus_backend.Models;
using velosaurus_backend.Services;

namespace velosaurus_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourController
{
    private readonly TourDatabaseService _databaseService;
    private readonly ILogger<TourController> _logger;

    public TourController(ILogger<TourController> logger, TourDatabaseService databaseService)
    {
        _logger = logger;
        _databaseService = databaseService;
        _logger.LogInformation("TourController instantiated...");
    }

    // async await ??
    [HttpGet]
    public async Task<List<Tour>?> Get()
    {
        try
        {
            return await _databaseService.GetAll();
        }
        catch (Exception e)
        {
            _logger.LogError("Error: {Msg}", e.Message);
        }

        return null;
    }

    [HttpGet("{id}")]
    public Task<Tour> GetById(string id)
    {
        return _databaseService.GetById(id);
    }

    [HttpPost]
    public Task Post(Tour tour)
    {
        return _databaseService.CreateTour(tour);
    }
}