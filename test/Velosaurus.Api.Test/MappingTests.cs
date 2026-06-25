using System;
using NUnit.Framework;
using Velosaurus.Api.DTO;
using Velosaurus.Api.Utils;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Test;

[TestFixture]
public class MappingTests
{
    [Test]
    public void CreateActivityDto_ToActivity_MapsPropertiesCorrectly()
    {
        // Arrange
        var dto = new CreateActivityDto
        {
            Name = "Morning Ride",
            Date = new DateTime(2024, 1, 2, 8, 30, 0, DateTimeKind.Utc),
            Length = 42.5f,
            AltitudeGain = 320.0f,
            ActivityType = ActivityType.Bike,
            Description = "Nice route",
            LocationId = 5
        };

        // Act
        var activity = dto.ToActivity();

        // Assert
        Assert.That(activity, Is.Not.Null);
        Assert.AreEqual(dto.Name, activity.Name);
        Assert.AreEqual(dto.Date, activity.Date);
        Assert.AreEqual(dto.Length, activity.Length);
        Assert.AreEqual(dto.AltitudeGain, activity.AltitudeGain);
        Assert.AreEqual(dto.ActivityType, activity.ActivityType);
        Assert.AreEqual(dto.Description, activity.Description);
        Assert.AreEqual(dto.LocationId, activity.LocationId);
    }
}
