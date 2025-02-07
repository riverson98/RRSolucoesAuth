namespace R_RSolucaoFinanceiraAuth.Domain.Interface;

public interface IRoleRepository
{
    Task<string> CreateRoleAsync(string role);
}
