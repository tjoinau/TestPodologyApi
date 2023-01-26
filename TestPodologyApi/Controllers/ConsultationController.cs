using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestPodologyApi.Interfaces;
using TestPodologyModel.DTOs;
using TestPodologyModel.Search;
using TestPodologyRepository.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestPodologyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;
        private readonly IMapper _mapper;

        public ConsultationController(IConsultationService consultationService, IMapper mapper)
        {
            _consultationService = consultationService;
            _mapper = mapper;
        }


        // GET: api/<ConsultationController>
        [HttpGet]
        public async Task<List<ConsultationDto>> Get([FromQuery]ConsultationSearch oSearch)
        {
            var result = _mapper.Map<List<ConsultationDto>>( await _consultationService.Get(oSearch).ConfigureAwait(false));

            return result;
        }

        // GET api/<ConsultationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConsultationController>
        [HttpPost]
        public async Task<ConsultationDto> Post([FromBody] NewConsultationDto newConsultation)
        {
            if(newConsultation == null)
            {
                return null;
            }
            var result = await _consultationService.AddNewConsultationAsync(_mapper.Map<Consultation>(newConsultation));

            var consultation = _mapper.Map<ConsultationDto>(result);

            return consultation;
        }

        // PUT api/<ConsultationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsultationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("GetFirstsAvailableDates")]
        public async Task<List<AvailableDatesDto>> GetFirstsAvailableDates([FromQuery]FirstsAvailableDatesSearch oSearch)
        {
            var xxx = await _consultationService.GetFirstsAvailableDates(oSearch);

            return xxx;
        }

    }
}
