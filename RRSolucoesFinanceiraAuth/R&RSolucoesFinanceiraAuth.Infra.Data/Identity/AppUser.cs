using Microsoft.AspNetCore.Identity;
using R_RSolucaoFinanceiraAuth.Domain.Entity;

namespace R_RSolucoesFinanceiraAuth.Infra.Data.Identity;

public class AppUser : IdentityUser
{
    public List<RefreshToken> RefreshTokens { get; set; }
    public bool IsRegistrationCompleted { get; set; } = false;
}
