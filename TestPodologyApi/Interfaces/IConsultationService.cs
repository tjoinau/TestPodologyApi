using TestPodologyModel.DTOs;

namespace TestPodologyApi.Interfaces
{
    public interface IConsultationService
    {
        Task<List<AvailableDatesDto>> GetFirstsAvailableDates();
    }
}