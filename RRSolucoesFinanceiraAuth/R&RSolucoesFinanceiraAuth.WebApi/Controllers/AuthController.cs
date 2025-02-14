using Microsoft.AspNetCore.Mvc;
using R_RSolucoesFinanceirasAuth.Application.DTOs;
using R_RSolucoesFinanceirasAuth.Application.Interfaces;
using R_RSolucoesFinanceirasAuth.Application.Messaging;
using System.Diagnostics;

namespace R_RSolucoesFinanceiraAuth.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    private readonly IUserService _service;
    private readonly IRoleService _roleService;
    private readonly IUserEventPublisher _eventPublisher;
    private readonly ILogger<AuthController> _log;
    public AuthController(IUserService userService, IRoleService roleService, IUserEventPublisher eventPublisher, ILogger<AuthController> log)
    {
        _service = userService;
        _roleService = roleService;
        _eventPublisher = eventPublisher;
        _log = log;
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
        var time = new Stopwatch();
        time.Start();
        _log.LogInformation("✨ Receiving new user registration, e-mail:{0}", userInfo.Email);
        var result = await _service.RegisterAsync(userInfo);
        time.Stop();

        if (result.Success)
        {
            _log.LogInformation("(✅ user registred successufuly, id:{0} e-mail:{1} elapsed time: {2} ms", result.Id, userInfo.Email, time.ElapsedMilliseconds);
            await _eventPublisher.PublishUserCreatedAsync(result.Id!, result.Email!, result.CreatedAt);
            return Ok(result);
        }

        _log.LogInformation("(❌ something went wrong with user registration error: {0}, elapsed time: {1} ms", result.Errors, time.ElapsedMilliseconds);
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
