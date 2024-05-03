using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using R_RSolucaoFinanceiraAuth.Domain.Entity;
using R_RSolucaoFinanceiraAuth.Domain.Interface;
using R_RSolucoesFinanceiraAuth.Infra.Data.Context;
using R_RSolucoesFinanceiraAuth.Infra.Data.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace R_RSolucoesFinanceiraAuth.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly JWT _jwt;
    private readonly AppDbContext _context;

    public UserRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
                          IOptions<JWT> jwt, AppDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwt = jwt.Value;
        _context = context;
    }

    public async Task<Authentication> GenerateAccessTokenAsync(TokenRequest tokenRequest)
    {
        var user = await _userManager.FindByEmailAsync(tokenRequest.Email!);

        if (user is null)
        {
            return new Authentication
                (
                    message: $"No Accounts Registered with {tokenRequest.Email}.",
                    isAuthenticated: false,
                    email: tokenRequest.Email,
                    roles: new List<string>(),
                    token: "invalid token",
                    refreshToken: "invalid refreshToken",
                    refreshTokenExpiration: DateTime.Now.AddSeconds(1)
                );
        }

        if (await _userManager.CheckPasswordAsync(user, tokenRequest.Password!))
        {
            var jwtSecurityToken = await CreateJwtToken(user);
            var roleList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

            if (user.RefreshTokens.Any(refresh => refresh.IsActive))
                user.RefreshTokens.Where(token => token.IsActive == true)
                                                           .FirstOrDefault();
            else
            {
                var refreshToken = CreateRefreshToken();
               
                var auth = new Authentication
                (
                    message: $"Token generated successfully",
                    isAuthenticated: true,
                    email: user.Email,
                    roles: roleList,
                    token: new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    refreshToken: refreshToken.Token,
                    refreshTokenExpiration: refreshToken.Expires
                );

                user.RefreshTokens.Add(refreshToken);
                _context.Update(user);
                _context.SaveChanges();

                return auth;
            }
            var validRefresh = user.RefreshTokens.Where(token => token.IsActive == true)
                                                 .FirstOrDefault();
            return new Authentication
               (
                   message: $"Refresh token is actived successfully",
                   isAuthenticated: true,
                   email: user.Email,
                   roles: roleList,
                   token: new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                   refreshToken: validRefresh!.Token,
                   refreshTokenExpiration: validRefresh.Expires
               );
        }

        return new Authentication
                (
                    message: $"Incorrect Credentials for user {user.Email}.",
                    isAuthenticated: false,
                    email: tokenRequest.Email,
                    roles: new List<string>(),
                    token: "invalid token",
                    refreshToken: "invalid refreshToken",
                    refreshTokenExpiration: DateTime.Now.AddMinutes(1)
                );
    }

    public async Task<string> AddRoleAsync(UserToRole userToRole)
    {
        var user = await _userManager.FindByEmailAsync(userToRole.Email!);
        if (user is null)
        {
            return $"No Accounts Registered with {userToRole.Email}.";
        }
        if (await _userManager.CheckPasswordAsync(user, userToRole.Password!))
        {
            var roleExists = Enum.GetNames(typeof(Authorization.Roles))
                                 .Any(role => role.ToLower().Equals(userToRole.Role!.ToLower()));
            if (roleExists)
            {
                var validRole = Enum.GetValues(typeof(Authorization.Roles))
                                    .Cast<Authorization.Roles>()
                                    .Where(role =>
                                           role.ToString().Equals(userToRole.Role,
                                                                  StringComparison.OrdinalIgnoreCase))
                                    .FirstOrDefault();

                await _userManager.AddToRoleAsync(user, validRole.ToString());

                return $"Added {userToRole.Role} to user {userToRole.Email}.";
            }
            return $"Role {userToRole.Role} not found.";
        }
        return $"Incorrect Credentials for user {user.Email}.";
    }

    public async Task<string> RegisterAsync(User user)
    {
        var IdentityUser = new AppUser
        {
            UserName = user.Email,
            Email = user.Email
        };

        var userWithSameEmail = await _userManager.FindByEmailAsync(user.Email!);

        if (userWithSameEmail is null)
        {
            var result = await _userManager.CreateAsync(IdentityUser, user.Password!);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(IdentityUser, Authorization.default_role.ToString());

            return $"User Registered with username {user.Email}";
        }
        else
            return $"Email {user.Email} is already registered.";
    }

    private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = new List<Claim>();

        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("uid", user.Id)
        }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key!));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;
    }

    private RefreshToken CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var generator = new RNGCryptoServiceProvider())
        {
            generator.GetBytes(randomNumber);

            return new RefreshToken
                (
                    token: Convert.ToBase64String(randomNumber),
                    expires: DateTime.UtcNow.AddDays(10),
                    created: DateTime.UtcNow,
                    revoked: null
                );

        }
    }
}
