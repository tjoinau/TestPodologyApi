using LinqKit;
using Microsoft.EntityFrameworkCore;
using TestPodologyApi.Interfaces;
using TestPodologyModel.Search;
using TestPodologyRepository.Data;
using TestPodologyRepository.Entities;

namespace TestPodologyApi.Services
{
    public class LocationService : ILocationService
    {
        public async Task<List<Location>> Get(LocationSearch locationSearch)
        {
            try
            {
                var pr = PredicateBuilder.New<Location>(true);

                if (locationSearch.DoctorId.HasValue)
                {
                    pr = pr.And(x => x.HealthCareProviderId == locationSearch.DoctorId.Value);
                }

                using (var db = new TestPodologyDBContext())
                {
                    var locationsDb = await db.Locations
                        .Where(pr)
                        .OrderBy(x => x.Name)
                        .ToListAsync()
                        .ConfigureAwait(false);

                    return locationsDb;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
