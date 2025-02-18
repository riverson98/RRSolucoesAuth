using Microsoft.AspNetCore.Mvc;
using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Application.Services;
using RRSolucoesFinanceiraUsers.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRSolucoesFinanceiraUsers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IService<PhoneEntity, PhoneDTO> _service;
        private readonly IPhoneService _phoneService;

        public PhoneController(IService<PhoneEntity, PhoneDTO> service, IPhoneService phoneService)
        {
            _service = service;
            _phoneService = phoneService;
        }

        // GET: api/<PhoneController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PhoneController>/5
        [HttpGet("{id:int:min(1)}", Name ="GetPhoneById")]
        public async Task<ActionResult<PhoneDTO>> Get(int id)
        {
            var phoneDto = await _phoneService.GetPhoneById(id);

            if (phoneDto is null)
                return NotFound("Sorry this address can be found in our database");

            return Ok(phoneDto);
        }

        // POST api/<PhoneController>
        [HttpPost]
        public async Task<ActionResult<PhoneDTO>> Post([FromBody] PhoneDTO phoneDto)
        {
            if (phoneDto is null)
                return BadRequest();

            var phoneDtoCreated = await _service.Add(phoneDto);

            return new CreatedAtRouteResult("GetPhoneById", new { id = phoneDtoCreated.Id }, phoneDtoCreated);
        }

        // PUT api/<PhoneController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PhoneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
