using System.ComponentModel.DataAnnotations;

namespace Velosaurus.Api.DTO;

public class LocationDto
{
    public string? Name { get; init; }

    [MaxLength(50)]
    public string? Region { get; set; }
}
