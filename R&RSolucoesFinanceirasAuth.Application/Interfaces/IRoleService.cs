namespace R_RSolucoesFinanceirasAuth.Application.Interfaces;

public interface IRoleService
{
    Task<string> CreateRoleAsync(string role);
}
