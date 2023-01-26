using TestPodologyModel.Search;
using TestPodologyRepository.Entities;

namespace TestPodologyApi.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> Get(PatientSearch oSearch);
    }
}