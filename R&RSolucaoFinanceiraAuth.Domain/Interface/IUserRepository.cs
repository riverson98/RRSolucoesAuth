﻿using R_RSolucaoFinanceiraAuth.Domain.Entity;

namespace R_RSolucaoFinanceiraAuth.Domain.Interface;

public interface IUserRepository
{
    Task<string> RegisterAsync(User user);
    Task<Authentication> GenerateAccessTokenAsync(TokenRequest request);
    Task<string> AddRoleAsync(UserToRole userToRole);
}