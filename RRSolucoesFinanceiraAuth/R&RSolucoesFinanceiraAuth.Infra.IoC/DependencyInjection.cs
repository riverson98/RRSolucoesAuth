using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using R_RSolucaoFinanceiraAuth.Domain.Entity;
using R_RSolucaoFinanceiraAuth.Domain.Interface;
using R_RSolucoesFinanceiraAuth.Infra.Data.Context;
using R_RSolucoesFinanceiraAuth.Infra.Data.Identity;
using R_RSolucoesFinanceiraAuth.Infra.Data.Repositories;
using R_RSolucoesFinanceirasAuth.Application.Interfaces;
using R_RSolucoesFinanceirasAuth.Application.Mappings;
using R_RSolucoesFinanceirasAuth.Application.Services;

namespace R_RSolucoesFinanceiraAuth.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var mySqlConnection = config.GetConnectionString("MySqlConnection");

        services.AddDbContext<AppDbContext>(options =>
                 options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection),
                 it => it.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

        services.Configure<JWT>(config.GetSection("JWT"));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        return services;
    }
}
