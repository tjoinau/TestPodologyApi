using TestPodologyModel.Search;
using TestPodologyRepository.Entities;

namespace TestPodologyApi.Interfaces
{
    public interface IConfigurationService
    {
        Task<Hcpconfiguration> Get(HCPConfigurationSearch oSearch);
        Task<Hcpconfiguration> InsertUpdateConfig(Hcpconfiguration configuration);
    }
}