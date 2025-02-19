using Microsoft.AspNetCore.Mvc;
using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRSolucoesFinanceiraUsers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<UserEntity, UserDTO> _service;
        private readonly IUserService _userService;
        public UserController(IService<UserEntity, UserDTO> service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }

        // GET: api/user/withDetails/{id}
        [HttpGet]
        [Route("withDetails/{id:guid}")]
        public async Task<IActionResult> GetUserWithDetailsAsync(Guid id)
        {
            var userDto = await _userService.GetUserWithDetailsAsync(id);
            if (userDto is null)
                return NotFound($"Sorry this user can be found in our database userId:{id}");
            
            return Ok(userDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<UserDTO>> GetUserById(Guid id)
        {
            var userDto = await _userService.GetUserById(id);

            if (userDto.Id is null)
                return NotFound($"Sorry this user can be found in our database userId:{id}");

            return Ok(userDto);
        }

        // POST api/User
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post(UserDTO userDto)
        {
            if (userDto is null)
                return BadRequest();

            var userDtoCreated = await _service.Add(userDto);

            return new CreatedAtRouteResult("GetUserById", new { id = userDtoCreated.Id }, userDtoCreated);
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(int id, UserDTO userDto)
        {
            if (!id.Equals(userDto.Id))
                return BadRequest("The id and the user id most be equals");

            var userDtoUpdated = await _service.Update(userDto);

            return Ok(userDtoUpdated);
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete(int id)
        {
            var userDto = await _service.GetAsync(user => user.Id.Equals(id));

            if (userDto is null)
                return NotFound("Any user found");

            await _service.Delete(userDto);

            return Ok(userDto);
        }
    }
}
