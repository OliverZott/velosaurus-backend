using Microsoft.AspNetCore.Mvc;
using Velosaurus.Api.Services;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourController : ControllerBase
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
    public async Task<List<Tour>?> GetTours()
    {
        try
        {
            return await _databaseService.GetToursAsync();
        }
        catch (Exception e)
        {
            _logger.LogError("Error: {Msg}", e.Message);
        }

        return null;
    }


    [HttpGet("{id:int}")]
    public async Task<Tour?> GetTourById(int id)
    {
        _logger.LogError("FUCK ME");
        var result = await _databaseService.GetTourAsync(id);
        if (result is null) _logger.LogError("Error: Tour with id {Id} not found", id);
        return result;
    }


    [HttpPost]
    public async Task<ActionResult<Tour>> CreateTour(Tour tour)
    {
        await _databaseService.AddTourAsync(tour);
        return CreatedAtAction(nameof(GetTourById), new { id = tour.Id }, tour);
    }
}