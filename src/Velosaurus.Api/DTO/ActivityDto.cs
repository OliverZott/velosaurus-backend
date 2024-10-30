using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.DTO;

public class ActivityDto
{
    public string Name { get; set; } = null!;
    public DateTime Date { get; set; }
    public float Length { get; set; }
    public float AltitudeGain { get; set; }
    public ActivityType ActivityType { get; set; }
}