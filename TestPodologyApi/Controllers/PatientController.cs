using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestPodologyApi.Interfaces;
using TestPodologyApi.Services;
using TestPodologyModel.DTOs;
using TestPodologyModel.Search;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestPodologyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public async Task<List<PatientDto>> Get([FromQuery] PatientSearch oSearch)
        {
            var patients = _mapper.Map<List<PatientDto>>(await _patientService.Get(oSearch).ConfigureAwait(false));

            return patients;
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
