using Microsoft.AspNetCore.Mvc;
using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRSolucoesFinanceiraUsers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IService<AddressEntity, AddressDTO> _service;
        private readonly IAddressService _addressService;
        public AddressController(IService<AddressEntity, AddressDTO> service, IAddressService addressService)
        {
            _service = service;
            _addressService = addressService;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddressController>/5
        [HttpGet("{id:int:min(1)}", Name = "GetAddressById")]
        public async Task<ActionResult<AddressDTO>> Get(int id)
        {
            var addressDto = await _addressService.GetAddressById(id);

            if (addressDto is null)
                return NotFound("Sorry this address can be found in our database");

            return Ok(addressDto);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult<AddressDTO>> Post(AddressDTO addressDto)
        {
            if (addressDto is null)
                return BadRequest();

            var userDtoCreated = await _service.Add(addressDto);

            return new CreatedAtRouteResult("GetAddressById", new { id = userDtoCreated.Id }, userDtoCreated);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
