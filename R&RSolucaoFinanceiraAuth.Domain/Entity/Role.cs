using R_RSolucaoFinanceiraAuth.Domain.Validation;

namespace R_RSolucaoFinanceiraAuth.Domain.Entity;

public sealed class Role
{
    public string? Name { get; private set; }

    public Role(string name)
    {
        ValidateDomain(name);
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name),
            "The name is required");

        Name = name;
    }
}
