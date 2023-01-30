using LinqKit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestPodologyApi.Interfaces;
using TestPodologyModel.Models;
using TestPodologyModel.Search;
using TestPodologyRepository.Data;
using TestPodologyRepository.Entities;

namespace TestPodologyApi.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public async Task<Hcpconfiguration> Get(HCPConfigurationSearch oSearch)
        {
            try
            {
                using (var db = new TestPodologyDBContext())
                {
                    var configurationPredicate = PredicateBuilder.New<Hcpconfiguration>(true);

                    if (!string.IsNullOrEmpty(oSearch.HCPId))
                    {
                        configurationPredicate = configurationPredicate.And(x => x.HcpId == oSearch.HCPId);
                    }

                    var result = await db.Hcpconfigurations.FirstOrDefaultAsync(configurationPredicate).ConfigureAwait(false);

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hcpconfiguration> InsertUpdateConfig(Hcpconfiguration configuration)
        {
            try
            {
                using (var db = new TestPodologyDBContext())
                {
                    var result = await db.Hcpconfigurations.FirstOrDefaultAsync(x => x.Id == configuration.Id).ConfigureAwait(false);

                    if (result == null)
                    {
                        var res = await db.AddAsync(configuration).ConfigureAwait(false);

                        db.SaveChanges();

                        return res.Entity;
                    }
                    else
                    {
                        result.Config = configuration.Config;

                        var res = db.Update(result);

                        db.SaveChanges();

                        return res.Entity;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
