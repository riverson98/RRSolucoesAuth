using R_RSolucaoFinanceiraAuth.Domain.Entity;
using R_RSolucoesFinanceirasAuth.Application.DTOs;

namespace R_RSolucoesFinanceirasAuth.Application.Interfaces;

public interface IUserService
{
    Task<string> RegisterAsync(UserDTO userDto);
    Task<AuthenticationDTO> GetTokenAsync(TokenRequestDTO request);
    Task<string> AddRoleAsync(UserToRoleDTO userToRoleDto);
}
