using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Velosaurus.Api.DTO;
using Velosaurus.Api.Repositories;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILogger<LocationController> logger;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public LocationController(ILogger<LocationController> logger, IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.logger = logger;
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }


    // GET: api/<Location>
    [HttpGet]
    public async Task<IEnumerable<LocationDto>> GetLocationsAsync()
    {
        var locations = await unitOfWork.Location.GetAllAsync();
        var locationDtos = mapper.Map<List<GetLocationDto>>(locations).ToList();
        return locationDtos;
    }

    // GET api/<Location>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetLocationDetailDto>> GetLocationById(int id)
    {
        var location = await unitOfWork.Location.GetAsync(id, l => l.Activities);
        var locationDto = mapper.Map<GetLocationDetailDto>(location);
        return Ok(locationDto);
    }

    // POST api/<Location>
    [HttpPost]
    public async Task<ActionResult<Location>> PostLocation([FromBody] LocationDto locationDto)
    {
        var location = mapper.Map<Location>(locationDto);
        await unitOfWork.Location.AddAsync(location);
        return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
    }

    // PUT api/<Location>/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDto locationDto)
    {
        if (!ModelState.IsValid || id < 0) return BadRequest(ModelState);

        var location = await unitOfWork.Location.GetAsync(id);
        mapper.Map(locationDto, location);

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
