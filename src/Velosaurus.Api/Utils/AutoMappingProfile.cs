using AutoMapper;
using Velosaurus.Api.DTO;
using Velosaurus.DatabaseManager.Models;

namespace Velosaurus.Api.Utils;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        CreateMap<Tour, GetTourDto>()
            .ForMember(dest => dest.TourType, opt => opt.MapFrom(src => src.TourType.ToString())).ReverseMap();
        CreateMap<CreateTourDto, Tour>();
        CreateMap<GetTourDetailDto, Tour>().ReverseMap();
    }
}