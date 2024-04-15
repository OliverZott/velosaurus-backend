using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Velosaurus.Api.DTO;
using Velosaurus.Api.Services;
using Velosaurus.Core.Exceptions;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourController : ControllerBase
{
    private readonly TourDatabaseService _databaseService;
    private readonly IMapper _mapper;


    public TourController(ILogger<TourController> logger, TourDatabaseService databaseService, IMapper mapper)
    {
        _databaseService = databaseService;
        _mapper = mapper;
        logger.LogInformation("TourController instantiated...");
    }


    [HttpGet]
    public async Task<ActionResult<List<GetTourDto>>> GetTours()
    {
        var tours = await _databaseService.GetToursAsync();
        var tourDtos = _mapper.Map<List<GetTourDto>>(tours);
        return Ok(tourDtos);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetTourDto>> GetTourById(int id)
    {
        var tour = await _databaseService.GetTourAsync(id);
        var tourDto = _mapper.Map<GetTourDetailDto>(tour);
        return tour == null ? throw new ItemNotFoundException("Tour", id) : Ok(tourDto);
    }


    [HttpPost]
    public async Task<ActionResult<Tour>> CreateTour(CreateTourDto createTourDto)
    {
        if (createTourDto.Date == DateTime.MinValue) createTourDto.Date = DateTime.UtcNow.AddHours(2);

        var tour = _mapper.Map<Tour>(createTourDto);
        await _databaseService.AddTourAsync(tour);
        return CreatedAtAction(nameof(GetTourById), new { id = tour.Id }, tour);
    }
}