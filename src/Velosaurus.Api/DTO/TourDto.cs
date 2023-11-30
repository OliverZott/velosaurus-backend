using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.DTO;

public class TourDto
{
    public string TourName { get; set; } = null!;
    public float Length { get; set; }
    public float AltitudeGain { get; set; }
    public TourType TourType { get; set; }
}