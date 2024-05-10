using R_RSolucoesFinanceirasAuth.Application.DTOs;

namespace R_RSolucoesFinanceirasAuth.Application.Interfaces;

public interface IUserService
{
    Task<bool> RegisterAsync(UserDTO userDto);
    Task<AuthenticationDTO> GetTokenAsync(TokenRequestDTO request);
    Task<string> AddRoleAsync(UserToRoleDTO userToRoleDto);
    Task<AuthenticationDTO> RefreshTokenAsync(string token);
}
