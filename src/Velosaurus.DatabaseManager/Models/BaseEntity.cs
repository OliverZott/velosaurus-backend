using System.ComponentModel.DataAnnotations;

namespace Velosaurus.DatabaseManager.Models;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}