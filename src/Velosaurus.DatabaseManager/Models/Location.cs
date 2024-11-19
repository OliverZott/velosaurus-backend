using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Velosaurus.DatabaseManager.Models;

// TODO: change to area/destination

[Table("Locations")]
public class Location : BaseEntity
{
    [MaxLength(50)]
    [Required]
    public string? Name { get; set; }

    [MaxLength(50)]
    public string? Region { get; set; }

    public IList<Activity> Activities { get; set; } = [];
}