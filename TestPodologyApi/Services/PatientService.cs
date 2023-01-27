using LinqKit;
using Microsoft.EntityFrameworkCore;
using TestPodologyApi.Interfaces;
using TestPodologyModel.Search;
using TestPodologyRepository.Data;
using TestPodologyRepository.Entities;

namespace TestPodologyApi.Services
{
    public class PatientService : IPatientService
    {
        public async Task<List<Patient>> Get(PatientSearch oSearch)
        {
            try
            {
                var pr = PredicateBuilder.New<Patient>(true);

                if (!string.IsNullOrEmpty(oSearch.Id))
                {
                    pr = pr.And(x => x.Id == oSearch.Id);
                }

                using (var db = new TestPodologyDBContext())
                {
                    var patientsDb = await db.Patients
                        .Where(pr)
                        .OrderBy(x => x.LastName)
                        .ToListAsync()
                        .ConfigureAwait(false);

                    return patientsDb;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
