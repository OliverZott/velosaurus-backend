using Microsoft.AspNetCore.Mvc;
using Velosaurus.Api.DTO;
using Velosaurus.Api.Repositories;
using Velosaurus.DatabaseManager.Models;
using Velosaurus.Api.Utils;

namespace Velosaurus.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController(IUnitOfWork unitOfWork) : ControllerBase
{
    // GET: api/<Location>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LocationDto>>> GetLocationsAsync()
    {
        var locations = await unitOfWork.Location.GetAllAsync();
        var locationDtos = locations.Select(l => l.ToGetLocationDto()).ToList();
        return Ok(locationDtos);
    }

    // GET api/<Location>/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetLocationDetailDto>> GetLocationById(int id)
    {
        var location = await unitOfWork.Location.GetAsync(id, l => l.Activities);
        var locationDto = location.ToGetLocationDetailDto();
        return Ok(locationDto);
    }

    // POST api/<Location>
    [HttpPost]
    public async Task<ActionResult<Location>> PostLocation([FromBody] LocationDto locationDto)
    {
        var location = locationDto.ToLocation();
        await unitOfWork.Location.AddAsync(location);
        return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
    }

    // PUT api/<Location>/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDto locationDto)
    {
        if (!ModelState.IsValid || id < 0) return BadRequest(ModelState);

        var location = await unitOfWork.Location.GetAsync(id);
        location.UpdateFrom(locationDto);

        await unitOfWork.Location.UpdateAsync(location!);
        return NoContent();
    }

    // DELETE api/<Location>/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        await unitOfWork.Location.GetAsync(id);
        await unitOfWork.Location.DeleteAsync(id);
        return NoContent();
    }
}
