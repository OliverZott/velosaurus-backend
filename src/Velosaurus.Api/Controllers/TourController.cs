using Microsoft.AspNetCore.Mvc;
using Velosaurus.Api.Services;
using Velosaurus.Core.Exceptions;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourController : ControllerBase
{
    private readonly TourDatabaseService _databaseService;


    public TourController(ILogger<TourController> logger, TourDatabaseService databaseService)
    {
        _databaseService = databaseService;
        logger.LogInformation("TourController instantiated...");
    }


    [HttpGet]
    public async Task<List<Tour>?> GetTours()
    {
        return await _databaseService.GetToursAsync();
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Tour>> GetTourById(int id)
    {
        var result = await _databaseService.GetTourAsync(id);
        return result == null ? throw new ItemNotFoundException("Tour", id) : (ActionResult<Tour>)Ok(result);
    }


    [HttpPost]
    public async Task<ActionResult<Tour>> CreateTour(Tour tour)
    {
        await _databaseService.AddTourAsync(tour);
        return CreatedAtAction(nameof(GetTourById), new { id = tour.Id }, tour);
    }
}