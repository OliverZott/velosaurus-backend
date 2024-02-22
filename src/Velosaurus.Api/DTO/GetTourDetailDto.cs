namespace Velosaurus.Api.DTO;

public class GetTourDetailDto : TourDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
}
