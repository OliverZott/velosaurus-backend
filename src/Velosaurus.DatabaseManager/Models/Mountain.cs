using System.ComponentModel.DataAnnotations;

namespace Velosaurus.DatabaseManager.Models;

public class Mountain : IEntity
{
    [MaxLength(50)]
    [Required]
    public string? Name { get; set; }

    [MaxLength(50)]
    public string? Region { get; set; }

    public IList<Tour> Tours { get; set; } = new List<Tour>();

    [Key]
    public int Id { get; set; }
}