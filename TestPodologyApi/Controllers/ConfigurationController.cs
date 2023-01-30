using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using TestPodologyApi.Interfaces;
using TestPodologyModel.DTOs;
using TestPodologyModel.Models;
using TestPodologyModel.Search;
using TestPodologyRepository.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestPodologyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        // GET: api/<ConfigurationController>
        [HttpGet]
        public async Task<HCPConfigurationDto> Get([FromQuery]HCPConfigurationSearch oSearch)
        {
            var result = await _configurationService.Get(oSearch).ConfigureAwait(false);
            if(result != null)
            {
                var resultDto = new HCPConfigurationDto()
                {
                    Id = result.Id,
                    HCPId = result.HcpId,
                    Config = JsonConvert.DeserializeObject<HCPConfigFormModel>(result.Config) ?? new HCPConfigFormModel()
                };

                return resultDto;
            }

            return new HCPConfigurationDto();
        }

        // GET api/<ConfigurationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConfigurationController>
        [HttpPost]
        public async Task Post([FromBody] HCPConfigurationDto value)
        {
            var config = JsonConvert.SerializeObject(value.Config);
            var hCPConfiguration = new Hcpconfiguration()
            {
                HcpId = value.HCPId,
                Config = config,
                Id = value.Id
            };

            var res = await _configurationService.InsertUpdateConfig(hCPConfiguration).ConfigureAwait(false);
            //var timeOnly = DateTime.ParseExact(value.Config.StartDay, "HH:mm",
            //                            CultureInfo.InvariantCulture).TimeOfDay;

        }

        // PUT api/<ConfigurationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConfigurationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
