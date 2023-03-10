using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Velosaurus.Api.Models;

public class Tour
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
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