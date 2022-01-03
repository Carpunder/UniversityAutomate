using AutoMapper;
using UniversityAutomate.Areas.Admin.Models;
using UniversityAutomate.Models;

namespace UniversityAutomate.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDTO>();

            CreateMap<University, UniversityDTO>()
                .ForMember(dest => dest.CityName, act => act.MapFrom(src => src.City.CityName));

            CreateMap<Group, GroupDTO>()
                .ForMember(dest => dest.UniversityName, act => act.MapFrom(src => src.University.UniversityName));

            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.CityName, act => act.MapFrom(src => src.City.CityName))
                .ForMember(dest => dest.GroupName, act => act.MapFrom(src => src.Group.GroupName))
                .ForMember(dest => dest.UniversityName, act => act.MapFrom(src => src.Group.University.UniversityName));
        }
    }
}
