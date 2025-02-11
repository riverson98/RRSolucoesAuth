using Microsoft.EntityFrameworkCore;
using RRSolucoesFinanceiraUsers.Domain.Entities;

namespace RRSolucoesFinanceiraUsers.Infra.Data.Context;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<DocumentEntity> Document { get; set; }
    public DbSet<PhoneEntity> Phone { get; set; }
    public DbSet<UserEntityRoles> User_role { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }
}
