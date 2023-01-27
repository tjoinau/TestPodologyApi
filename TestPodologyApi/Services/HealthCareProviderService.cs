using LinqKit;
using Microsoft.EntityFrameworkCore;
using TestPodologyApi.Interfaces;
using TestPodologyModel.Search;
using TestPodologyRepository.Data;
using TestPodologyRepository.Entities;

namespace TestPodologyApi.Services
{
    public class HealthCareProviderService : IHealthCareProviderService
    {
        public async Task<List<HealthCareProvider>> Get(HealthCareProviderSearch oSearch)
        {
            try
            {
                var pr = PredicateBuilder.New<HealthCareProvider>(true);

                if (!string.IsNullOrEmpty(oSearch.Id))
                {
                    pr = pr.And(x => x.Id == oSearch.Id);
                }

                using (var db = new TestPodologyDBContext())
                {
                    var healthCareProvidersDb = await db.HealthCareProviders
                        .Where(pr)
                        .OrderBy(x => x.LastName)
                        .ToListAsync()
                        .ConfigureAwait(false);

                    return healthCareProvidersDb;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
