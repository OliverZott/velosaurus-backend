using Microsoft.AspNetCore.Mvc;
using velosaurus_backend.Models;
using velosaurus_backend.Services;

namespace velosaurus_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourController
{
    private readonly ILogger<Tour> _logger;
    private readonly TourDatabaseService _databaseService;

    public TourController(ILogger<Tour> logger, TourDatabaseService databaseService)
    {
        _logger = logger;
        _databaseService = databaseService;
        _logger.LogInformation("TourController instantiated...");
    }

    // async await ??
    [HttpGet]
    public Task<List<Tour>> Get()
    {
        return _databaseService.GetAll();
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
