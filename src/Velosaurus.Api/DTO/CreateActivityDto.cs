namespace Velosaurus.Api.DTO;

public class CreateActivityDto : ActivityDto
{
    public string Description { get; set; } = null!;
    public int LocationId { get; set; }
}