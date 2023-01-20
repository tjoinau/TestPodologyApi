using TestPodologyModel.Search;
using TestPodologyRepository.Entities;

namespace TestPodologyApi.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> Get(LocationSearch locationSearch);
    }
}