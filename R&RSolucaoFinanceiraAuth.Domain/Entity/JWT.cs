using R_RSolucaoFinanceiraAuth.Domain.Validation;

namespace R_RSolucaoFinanceiraAuth.Domain.Entity;

public sealed class JWT
{
    public string? Key { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public double DurationInMinutes { get; set; }
}
