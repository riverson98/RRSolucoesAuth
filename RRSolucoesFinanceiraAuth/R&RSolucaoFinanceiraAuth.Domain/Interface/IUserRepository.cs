using R_RSolucaoFinanceiraAuth.Domain.Entity;

namespace R_RSolucaoFinanceiraAuth.Domain.Interface;

public interface IUserRepository
{
    Task<bool> RegisterAsync(User user);
    Task<Authentication> GenerateAccessTokenAsync(TokenRequest request);
    Task<string> AddRoleAsync(UserToRole userToRole);
    Task<Authentication> RefreshTokenAsync(string token);
}
