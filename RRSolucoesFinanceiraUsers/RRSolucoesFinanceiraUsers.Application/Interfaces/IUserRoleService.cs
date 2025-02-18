using RRSolucoesFinanceiraUsers.Application.DTOs;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IUserRoleService
{
    Task<UserRolesDTO> GetUserRoleById(int? id);
}
