using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Velosaurus.Api.DTO;
using Velosaurus.Api.Repositories;
using Velosaurus.Core.Exceptions;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public ActivityController(ILogger<ActivityController> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        logger.LogInformation("ActivityController instantiated...");
    }


    [HttpGet]
    public async Task<ActionResult<List<GetActivityDto>>> GetActivities()
    {
        var activities = await _unitOfWork.Activity.GetAllAsync();
        var activityDtos = _mapper.Map<List<GetActivityDto>>(activities);
        return Ok(activityDtos);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetActivityDto>> GetActivityById(int id)
    {
        var activity = await _unitOfWork.Activity.GetAsync(id, t => t.Location);
        var activityDto = _mapper.Map<GetActivityDetailDto>(activity);
        return activity == null ? throw new ItemNotFoundException("Activity", id) : Ok(activityDto);
    }


    [HttpPost]
    public async Task<ActionResult<Activity>> CreateActivity(CreateActivityDto createActivityDto)
    {
        if (createActivityDto.Date == DateTime.MinValue) createActivityDto.Date = DateTime.UtcNow.AddHours(2);

        var activity = _mapper.Map<Activity>(createActivityDto);
        await _unitOfWork.Activity.AddAsync(activity);
        return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
    }
}