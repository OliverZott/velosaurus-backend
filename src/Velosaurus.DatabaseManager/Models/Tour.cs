using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Velosaurus.DatabaseManager.Models;

public class Tour : IEntity
{
    [MaxLength(50)]
    [Required]
    public string? TourName { get; set; }

    public DateTime Date { get; set; }
    public float Length { get; set; }
    public float AltitudeGain { get; set; }
    public TourType TourType { get; set; }

    [MaxLength(250)]
    public string Description { get; set; } = null!;


    [ForeignKey(nameof(MountainId))]
    public int MountainId { get; set; }

    public Mountain? Mountain { get; set; }

    [Key]
    public int Id { get; set; }
}

public enum TourType
{
    MountainBike,
    Nordic,
    Ski,
    Hiking
}