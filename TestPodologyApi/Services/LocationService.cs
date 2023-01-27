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
                var pr = PredicateBuilder.New<LocationHealthCareProvider>(true);

                if (!string.IsNullOrEmpty(locationSearch.DoctorId))
                {
                    pr = pr.And(x => x.HealthCareProviderId == locationSearch.DoctorId);
                }

                using (var db = new TestPodologyDBContext())
                {
                    var locationsDb = await db.LocationHealthCareProviders
                        .Include(x => x.Location)
                        .Where(pr)
                        .OrderBy(x => x.Location.Name)
                        .Select(x => x.Location)
                        .Distinct()
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
