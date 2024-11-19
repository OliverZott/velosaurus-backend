namespace Velosaurus.Api.DTO;

public class GetActivityDetailDto : ActivityDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public LocationDto? Location { get; set; }
}
