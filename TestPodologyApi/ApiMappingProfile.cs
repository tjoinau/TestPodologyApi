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

            CreateMap<Consultation, NewConsultationDto>().ReverseMap();
            CreateMap<Consultation, ConsultationDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<HealthCareProvider, HealthCareProviderDto>().ReverseMap();
        }
    }
}
