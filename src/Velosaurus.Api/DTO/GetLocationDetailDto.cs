using System.ComponentModel.DataAnnotations;

namespace Velosaurus.Api.DTO;

public class GetLocationDetailDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    [MaxLength(50)]
    public string? Region { get; set; }

    public IList<ActivityDto> Activities { get; set; } = [];
}
