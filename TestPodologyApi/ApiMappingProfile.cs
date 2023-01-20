using AutoMapper;
using TestPodologyModel.DTOs;
using TestPodologyRepository.Entities;

namespace TestPodologyApi
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}
