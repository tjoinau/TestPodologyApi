using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestPodologyApi.Interfaces;
using TestPodologyModel.DTOs;
using TestPodologyModel.Search;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestPodologyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCareProviderController : ControllerBase
    {
        private readonly IHealthCareProviderService _healthCareProviderService;
        private readonly IMapper _mapper;

        public HealthCareProviderController(IHealthCareProviderService healthCareProviderService, IMapper mapper)
        {
            _healthCareProviderService = healthCareProviderService;
            _mapper = mapper;
        }

        // GET: api/<HealthCareProviderController>
        [HttpGet]
        public async Task<List<HealthCareProviderDto>> Get([FromQuery] HealthCareProviderSearch oSearch)
        {
            var healthCareProviders = _mapper.Map<List<HealthCareProviderDto>>( await _healthCareProviderService.Get(oSearch).ConfigureAwait(false));

            return healthCareProviders;
        }

        // GET api/<HealthCareProviderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HealthCareProviderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HealthCareProviderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HealthCareProviderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
