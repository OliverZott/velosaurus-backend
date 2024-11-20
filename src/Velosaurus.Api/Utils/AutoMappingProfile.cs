using AutoMapper;
using Velosaurus.Api.DTO;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Utils;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<Activity, GetActivityDto>()
            .ForMember(dest => dest.ActivityType, opt => opt.MapFrom(src => src.ActivityType.ToString())).ReverseMap();
        CreateMap<CreateActivityDto, Activity>()
            .ForMember(dest => dest.ActivityType, opt => opt.MapFrom(src => src.ActivityType.ToString())).ReverseMap();
        CreateMap<GetActivityDetailDto, Activity>().ReverseMap();

        CreateMap<LocationDto, Location>().ReverseMap();
        CreateMap<Location, LocationDto>().ReverseMap();

        CreateMap<GetLocationDto, Location>().ReverseMap();

        CreateMap<GetLocationDetailDto, Location>().ReverseMap();
        CreateMap<Location, GetLocationDetailDto>()
            .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.Activities.Select(a => new ActivityDto
            {
                Name = a.Name,
                Date = a.Date,
                Length = a.Length,
                AltitudeGain = a.AltitudeGain,
                ActivityType = a.ActivityType // Ensuring the enum is mapped to its string representation
            }))).ReverseMap();
    }
}