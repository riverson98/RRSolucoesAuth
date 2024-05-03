using R_RSolucaoFinanceiraAuth.Domain.Interface;
using R_RSolucoesFinanceirasAuth.Application.Interfaces;

namespace R_RSolucoesFinanceirasAuth.Application.Services;

public class RoleService : IRoleService
{
    private IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public Task<string> CreateRoleAsync(string role)
    {
        return _roleRepository.CreateRoleAsync(role);
    }
}
