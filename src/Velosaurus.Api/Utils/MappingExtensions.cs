using System.Linq;
using Velosaurus.Api.DTO;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Utils;

public static class MappingExtensions
{
    // Activity -> DTO
    public static ActivityDto ToActivityDto(this Activity src)
    {
        return new ActivityDto
        {
            Name = src.Name!,
            Date = src.Date,
            Length = src.Length,
            AltitudeGain = src.AltitudeGain,
            ActivityType = src.ActivityType
        };
    }

    public static GetActivityDto ToGetActivityDto(this Activity src)
    {
        var dto = src.ToActivityDto() as ActivityDto;
        return new GetActivityDto
        {
            Id = src.Id,
            Name = src.Name!,
            Date = src.Date,
            Length = src.Length,
            AltitudeGain = src.AltitudeGain,
            ActivityType = src.ActivityType
        };
    }

    public static GetActivityDetailDto ToGetActivityDetailDto(this Activity src)
    {
        return new GetActivityDetailDto
        {
            Id = src.Id,
            Name = src.Name!,
            Date = src.Date,
            Length = src.Length,
            AltitudeGain = src.AltitudeGain,
            ActivityType = src.ActivityType,
            Description = src.Description,
            Location = src.Location?.ToLocationDto()
        };
    }

    public static Activity ToActivity(this CreateActivityDto src)
    {
        return new Activity
        {
            Name = src.Name,
            Date = src.Date,
            Length = src.Length,
            AltitudeGain = src.AltitudeGain,
            ActivityType = src.ActivityType,
            Description = src.Description,
            LocationId = src.LocationId > 0 ? src.LocationId : null
        };
    }

    public static void UpdateFrom(this Activity target, CreateActivityDto src)
    {
        target.Name = src.Name;
        target.Date = src.Date;
        target.Length = src.Length;
        target.AltitudeGain = src.AltitudeGain;
        target.ActivityType = src.ActivityType;
        target.Description = src.Description;
        target.LocationId = src.LocationId > 0 ? src.LocationId : null;
    }

    // Location -> DTO
    public static LocationDto ToLocationDto(this Location src)
    {
        return new LocationDto
        {
            Name = src.Name,
            Region = src.Region
        };
    }

    public static GetLocationDto ToGetLocationDto(this Location src)
    {
        return new GetLocationDto
        {
            Id = src.Id,
            Name = src.Name,
            Region = src.Region
        };
    }

    public static GetLocationDetailDto ToGetLocationDetailDto(this Location src)
    {
        return new GetLocationDetailDto
        {
            Id = src.Id,
            Name = src.Name,
            Region = src.Region,
            Activities = src.Activities?.Select(a => a.ToActivityDto()).ToList() ?? new List<ActivityDto>()
        };
    }

    public static Location ToLocation(this LocationDto src)
    {
        return new Location
        {
            Name = src.Name,
            Region = src.Region
        };
    }

    public static void UpdateFrom(this Location target, LocationDto src)
    {
        target.Name = src.Name;
        target.Region = src.Region;
    }
}
