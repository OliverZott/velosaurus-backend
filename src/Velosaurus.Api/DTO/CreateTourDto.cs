using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.DTO;

public class CreateTourDto : TourDto
{
    public DateTime Date { get; set; }
    public TourType TourType { get; set; }
}