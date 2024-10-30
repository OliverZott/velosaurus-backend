using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Velosaurus.DatabaseManager.Models;


[Table("Activities")]
public class Activity : BaseEntity
{
    [MaxLength(50)]
    [Required]
    public string? Name { get; set; }
    public DateTime Date { get; set; }
    public float Length { get; set; }
    public float AltitudeGain { get; set; }
    public ActivityType ActivityType { get; set; }
    [MaxLength(250)]
    public string Description { get; set; } = null!;


    [ForeignKey(nameof(LocationId))]
    public int? LocationId { get; set; }
    public Location? Location { get; set; }
}