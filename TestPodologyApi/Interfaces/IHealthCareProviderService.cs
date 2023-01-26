using TestPodologyModel.Search;
using TestPodologyRepository.Entities;

namespace TestPodologyApi.Interfaces
{
    public interface IHealthCareProviderService
    {
        Task<List<HealthCareProvider>> Get(HealthCareProviderSearch oSearch);
    }
}