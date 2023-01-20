using TestPodologyModel.DTOs;
using TestPodologyModel.Search;

namespace TestPodologyApi.Interfaces
{
    public interface IConsultationService
    {
        Task<List<AvailableDatesDto>> GetFirstsAvailableDates(FirstsAvailableDatesSearch oSearch);
    }
}