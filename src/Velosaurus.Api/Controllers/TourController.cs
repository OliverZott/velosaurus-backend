using Microsoft.AspNetCore.Mvc;
using Velosaurus.Api.Services;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Controllers;

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


    [HttpGet]
    public async Task<List<Tour>?> Get()
    {
        try
        {
            return await _databaseService.GetAllAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Error: {Msg}", e.Message);
        }

        return null;
    }


    [HttpGet("{id:int}")]
    public Task<Tour> GetById(int? id)
    {
        return _databaseService.GetAsync(id);
    }


    [HttpPost]
    public async Task<ActionResult<Tour>> Create(Tour tour)
    {
        await _databaseService.AddAsync(tour);
        return tour;
    }
}