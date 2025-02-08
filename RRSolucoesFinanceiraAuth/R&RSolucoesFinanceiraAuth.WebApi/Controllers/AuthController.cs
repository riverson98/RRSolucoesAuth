using Microsoft.AspNetCore.Mvc;
using R_RSolucoesFinanceirasAuth.Application.DTOs;
using R_RSolucoesFinanceirasAuth.Application.Interfaces;

namespace R_RSolucoesFinanceiraAuth.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IUserService _service;
    private readonly IRoleService _roleService;
    public AuthController(IUserService userService, IRoleService roleService)
    {
        _service = userService;
        _roleService = roleService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> GetTokenAsync(TokenRequestDTO requestDto)
    {
        var result = await _service.GetTokenAsync(requestDto);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult> RegisterAsync(UserDTO userInfo)
    {
        var result = await _service.RegisterAsync(userInfo);

        if (result.Success) 
            return Ok(result);

        return BadRequest(result);
    }

    [HttpPost("registerrole")]
    public async Task<ActionResult> RegisterRoleAsync(RoleDTO roleInfo)
    {

        var result = await _roleService.CreateRoleAsync(roleInfo.Name!);
        return Ok(result);
    }

    [HttpPost("addusertorole")]
    public async Task<ActionResult> AddRoleAsync(UserToRoleDTO userToRoleDto)
    {

        var result = await _service.AddRoleAsync(userToRoleDto);
        return Ok(result);
    }

    [HttpPost("refreshtoken")]
    public async Task<ActionResult> RefreshToken(string refreshToken)
    {
        var response = await _service.RefreshTokenAsync(refreshToken!);

        return Ok(response);
    }
}
