using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;
using RRSolucoesFinanceiraUsers.Infra.Data.Repository;

namespace RRSolucoesFinanceiraUsers.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var mySqlConnection = config.GetConnectionString("MySqlConnection");

        services.AddDbContext<ApplicationDBContext>(options =>
                 options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection),
                 it => it.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

        services.AddScoped<IUserEntityRepository, UserEntityRepository>();
        services.AddScoped<IUserEntityRolesRepository, UserEntityRolesRepository>();
        services.AddScoped<IAddressEntityRepository, AddressEntityRepository>();
        services.AddScoped<IDocumentEntityRepository, DocumentEntityRepository>();
        services.AddScoped<IPhoneEntityRepository, PhoneEntityRepository>();

        return services;
    }
}
