using TestPodologyModel.DTOs;
using TestPodologyModel.Search;
using TestPodologyRepository.Entities;

namespace TestPodologyApi.Interfaces
{
    public interface IConsultationService
    {
        Task<Consultation> AddNewConsultationAsync(Consultation newConsultation);
        Task<List<Consultation>> Get(ConsultationSearch oSearch);
        Task<List<AvailableDatesDto>> GetFirstsAvailableDates(FirstsAvailableDatesSearch oSearch);
    }
}