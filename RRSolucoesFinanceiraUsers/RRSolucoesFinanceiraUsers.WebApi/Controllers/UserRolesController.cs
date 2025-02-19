using Microsoft.AspNetCore.Mvc;
using RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Application.Services;
using RRSolucoesFinanceiraUsers.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRSolucoesFinanceiraUsers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IService<UserEntityRoles, UserRolesDTO> _service;
        private readonly IUserRoleService _roleService;

        public UserRolesController(IService<UserEntityRoles, UserRolesDTO> service, IUserRoleService roleService)
        {
            _service = service;
            _roleService = roleService;
        }

        // GET: api/<UserRolesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserRolesController>/5
        [HttpGet("{id:int:min(1)}", Name = "GetUserRoleById")]
        public async Task<ActionResult<UserRolesDTO>> Get(int id)
        {
            var roleDto = await _roleService.GetUserRoleById(id);

            if (roleDto is null)
                return NotFound("Sorry this address can be found in our database");

            return Ok(roleDto);
        }

        // POST api/<UserRolesController>
        [HttpPost]
        public async Task<ActionResult<UserRolesDTO>> Post(UserRolesDTO rolesDTO)
        {
            if (rolesDTO is null)
                return BadRequest();

            var roleDtoCreated = await _service.Add(rolesDTO);

            return new CreatedAtRouteResult("GetUserRoleById", new { id = roleDtoCreated.Id }, roleDtoCreated);
        }

        // PUT api/<UserRolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserRolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
