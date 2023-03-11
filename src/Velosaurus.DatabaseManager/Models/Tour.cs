namespace Velosaurus.DatabaseManager.Models;

public class Tour
{
    public int Id { get; set; }

    public string TourName { get; set; } = null!;
    public DateTime Date { get; set; }
    public float Length { get; set; }
    public float AltitudeGain { get; set; }
    public TourType TourType { get; set; }
}

public enum TourType
{
    MountainBike,
    Nordic,
    Ski
}