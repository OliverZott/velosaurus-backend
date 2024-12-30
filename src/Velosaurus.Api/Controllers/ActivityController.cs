using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using Velosaurus.Api.DTO;
using Velosaurus.Api.Repositories;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;


    public ActivityController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<List<GetActivityDto>>> GetActivities(int pageNumber = 1, int pageSize = 3)
    {
        if (pageNumber < 1 || pageSize < 1) return BadRequest("Page number and size must be greater than 0");

        var (activities, activityCount) = await _unitOfWork.Activity.GetAllPaginatedAsync(pageNumber, pageSize);
        var pageCount = (int)Math.Ceiling(activityCount / (double)pageSize);

        var activityDtos = _mapper.Map<List<GetActivityDto>>(activities);

        var metadata = new PaginationMetadata
        {
            TotalItems = activityCount,
            PageSize = pageSize,
            CurrentPage = pageNumber,
            TotalPages = pageCount,
            HasNextPage = pageNumber < pageCount,
            HasPreviousPage = pageNumber > 1
        };

        var pagedResponse = new PagedResponse<GetActivityDto>(activityDtos, metadata);

        // TODO remove as soon as global JsonSerializer options work correctly
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };

        var serializedPagedResponse = JsonSerializer.Serialize(pagedResponse);

        return Ok(serializedPagedResponse);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetActivityDto>> GetActivityById(int id) 
    {
        var activity = await _unitOfWork.Activity.GetAsync(id, a => a.Location);
        var activityDto = _mapper.Map<GetActivityDetailDto>(activity);
        return Ok(JsonSerializer.Serialize(activityDto));
    }

    [HttpPost]
    public async Task<ActionResult<Activity>> PostActivity(CreateActivityDto createActivityDto)
    {
        if (createActivityDto.Date == DateTime.MinValue) createActivityDto.Date = DateTime.UtcNow.AddHours(2);

        var activity = _mapper.Map<Activity>(createActivityDto);
        await _unitOfWork.Activity.AddAsync(activity);
        return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateActivity(int id, [FromBody] CreateActivityDto createActivityDto)
    {
        if (!ModelState.IsValid || id < 1) return BadRequest(ModelState);

        var activity = await _unitOfWork.Activity.GetAsync(id, a => a.Location);

        _mapper.Map(createActivityDto, activity); // mapping on existing object (instead of creating new object)

        await _unitOfWork.Activity.UpdateAsync(activity!);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteActivity(int id)
    {
        await _unitOfWork.Activity.GetAsync(id);  // checking if it even exists
        await _unitOfWork.Activity.DeleteAsync(id);
        return NoContent();
    }
}
