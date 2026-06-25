using Microsoft.AspNetCore.Mvc;
using Velosaurus.Api.DTO;
using Velosaurus.Api.Repositories;
using Velosaurus.DatabaseManager.Models;
using Velosaurus.Api.Utils;

namespace Velosaurus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController(IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<GetActivityDto>>> GetActivities(int pageNumber = 1, int pageSize = 3)
    {
        if (pageNumber < 1 || pageSize < 1) return BadRequest("Page number and size must be greater than 0");

        var (activities, activityCount) = await unitOfWork.Activity.GetAllPaginatedAsync(pageNumber, pageSize);
        var pageCount = (int)Math.Ceiling(activityCount / (double)pageSize);

        var activityDtos = activities.Select(a => a.ToGetActivityDto()).ToList();

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
        return Ok(pagedResponse);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetActivityDto>> GetActivityById(int id) 
    {
        var activity = await unitOfWork.Activity.GetAsync(id, a => a.Location);
        var activityDto = activity.ToGetActivityDetailDto();
        return Ok(activityDto);
    }

    [HttpPost]
    public async Task<ActionResult<Activity>> PostActivity(CreateActivityDto createActivityDto)
    {
        if (createActivityDto.Date == DateTime.MinValue) createActivityDto.Date = DateTime.UtcNow.AddHours(2);

        var activity = createActivityDto.ToActivity();
        await unitOfWork.Activity.AddAsync(activity);
        return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateActivity(int id, [FromBody] CreateActivityDto createActivityDto)
    {
        if (!ModelState.IsValid || id < 1) return BadRequest(ModelState);

        var activity = await unitOfWork.Activity.GetAsync(id, a => a.Location);

        activity.UpdateFrom(createActivityDto); // update existing object with values from DTO

        await unitOfWork.Activity.UpdateAsync(activity!);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteActivity(int id)
    {
        await unitOfWork.Activity.GetAsync(id);  // checking if it even exists
        await unitOfWork.Activity.DeleteAsync(id);
        return NoContent();
    }
}
