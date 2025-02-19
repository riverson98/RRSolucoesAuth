using RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IUserRoleService
{
    Task<UserRolesDTO> GetUserRoleById(int? id);
}
