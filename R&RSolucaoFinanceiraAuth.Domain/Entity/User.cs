﻿using R_RSolucaoFinanceiraAuth.Domain.Validation;

namespace R_RSolucaoFinanceiraAuth.Domain.Entity;

public sealed class User
{
    public string? Email { get; private set; }
    public string? Password { get; private set; }
    public string? ConfirmPassword { get; private set; }

    public User(string? email, string? password, string? confirmPassword)
    {
        ValidateDomain(email, password, confirmPassword);
    }

    private void ValidateDomain(string? email, string? password, string? confirmPassword)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
            "The issuer is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(password),
            "The audience is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(confirmPassword),
            "You must confirm you password");

        DomainExceptionValidation.When(!password!.Equals(confirmPassword),
            "Passwords don't match");

        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
    }
}
