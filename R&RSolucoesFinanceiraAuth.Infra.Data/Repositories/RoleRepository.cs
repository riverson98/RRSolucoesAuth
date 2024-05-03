using Microsoft.AspNetCore.Identity;
using R_RSolucaoFinanceiraAuth.Domain.Entity;
using R_RSolucaoFinanceiraAuth.Domain.Interface;

namespace R_RSolucoesFinanceiraAuth.Infra.Data.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleRepository(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<string> CreateRoleAsync(string role)
    {
        var result = await _roleManager.CreateAsync(new IdentityRole(role));
        
        if(result.Succeeded)
            return $"Role registered with name {role}";
        else
            return $"Issue adding the new {role} role";
    }
}
