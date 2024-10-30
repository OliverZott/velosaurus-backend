using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Velosaurus.Api.DTO;
using Velosaurus.Api.Repositories;
using Velosaurus.Core.Exceptions;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TourController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public TourController(ILogger<TourController> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        logger.LogInformation("TourController instantiated...");
    }


    [HttpGet]
    public async Task<ActionResult<List<GetTourDto>>> GetTours()
    {
        var tours = await _unitOfWork.Tour.GetAllAsync();
        var tourDtos = _mapper.Map<List<GetTourDto>>(tours);
        return Ok(tourDtos);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetTourDto>> GetTourById(int id)
    {
        var tour = await _unitOfWork.Tour.GetAsync(id, t => t.Mountain);
        var tourDto = _mapper.Map<GetTourDetailDto>(tour);
        return tour == null ? throw new ItemNotFoundException("Tour", id) : Ok(tourDto);
    }


    [HttpPost]
    public async Task<ActionResult<Tour>> CreateTour(CreateTourDto createTourDto)
    {
        if (createTourDto.Date == DateTime.MinValue) createTourDto.Date = DateTime.UtcNow.AddHours(2);

        var tour = _mapper.Map<Tour>(createTourDto);
        await _unitOfWork.Tour.AddAsync(tour);
        return CreatedAtAction(nameof(GetTourById), new { id = tour.Id }, tour);
    }
}