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
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LocationController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    // GET: api/<Location>
    [HttpGet]
    public async Task<IEnumerable<LocationDto>> GetLocationsAsync()
    {
        var locations = await _unitOfWork.Location.GetAllAsync();
        var locationDtos = _mapper.Map<List<GetLocationDto>>(locations).ToList();
        return locationDtos;
    }

    // GET api/<Location>/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetLocationDetailDto>> GetLocationById(int id)
    {
        var location = await _unitOfWork.Location.GetAsync(id, l => l.Activities);
        var locationDto = _mapper.Map<GetLocationDetailDto>(location);
        return Ok(locationDto);
    }

    // POST api/<Location>
    [HttpPost]
    public async Task<ActionResult<Location>> PostLocation([FromBody] LocationDto locationDto)
    {
        var location = _mapper.Map<Location>(locationDto);
        await _unitOfWork.Location.AddAsync(location);
        return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
    }

    // PUT api/<Location>/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateLocation(int id, [FromBody] LocationDto locationDto)
    {
        if (!ModelState.IsValid || id < 0) return BadRequest(ModelState);

        var location = await _unitOfWork.Location.GetAsync(id);
        _mapper.Map(locationDto, location);

        await _unitOfWork.Location.UpdateAsync(location!);
        return NoContent();
    }

    // DELETE api/<Location>/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        await _unitOfWork.Location.GetAsync(id);
        await _unitOfWork.Location.DeleteAsync(id);
        return NoContent();
    }
}