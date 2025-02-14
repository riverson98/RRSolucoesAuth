using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Application.Mappings;
using RRSolucoesFinanceiraUsers.Application.Services;
using RRSolucoesFinanceiraUsers.Application.Services.Events;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;
using RRSolucoesFinanceiraUsers.Infra.Data.Repository;
using Shared.Application.Events;

namespace RRSolucoesFinanceiraUsers.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var mySqlConnection = config.GetConnectionString("MySqlConnection");

        services.AddLogging();

        services.AddDbContext<ApplicationDBContext>(options =>
                 options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection),
                 it => it.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

        //Domain layer
        services.AddScoped<IUserEntityRepository, UserEntityRepository>();
        services.AddScoped<IUserEntityRolesRepository, UserEntityRolesRepository>();
        services.AddScoped<IAddressEntityRepository, AddressEntityRepository>();
        services.AddScoped<IDocumentEntityRepository, DocumentEntityRepository>();
        services.AddScoped<IPhoneEntityRepository, PhoneEntityRepository>();
        services.AddScoped(typeof(IUnityOfWork<>), typeof(UnityOfWork<>));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        //Application layer
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IPhoneService, PhoneService>();
        services.AddScoped(typeof(IService<,>), typeof(Service<,>));

        //automapper
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        //RabbitMQ
        services.AddMassTransit(it =>
        {
            it.AddConsumer<UserCreatedConsumer>();

            it.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(config.GetConnectionString("RabbitMq"));

                cfg.ConfigureEndpoints(context);
            });
        });
        

        return services;
    }
}
