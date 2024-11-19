using System.ComponentModel.DataAnnotations;

namespace Velosaurus.Api.DTO;

public class LocationDto
{
    public string? Name { get; set; }

    [MaxLength(50)]
    public string? Region { get; set; }
}
