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
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        // GET: api/<LocationController>
        [HttpGet]
        public async Task<List<LocationDto>> Get([FromQuery] LocationSearch locationSearch)
        {
            var locations = await _locationService.Get(locationSearch);

            var locationsDto = _mapper.Map<List<LocationDto>>(locations);

            return locationsDto;
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LocationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
