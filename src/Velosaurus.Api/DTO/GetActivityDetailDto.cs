namespace Velosaurus.Api.DTO;

// TODO get locations/activities respectively for parent
public class GetActivityDetailDto : ActivityDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
}
