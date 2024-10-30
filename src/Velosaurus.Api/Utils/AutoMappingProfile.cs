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
        CreateMap<CreateActivityDto, Activity>();
        CreateMap<GetActivityDetailDto, Activity>().ReverseMap();
    }
}