using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RRSolucoesFinanceiraUsers.Domain.Entities;

namespace RRSolucoesFinanceiraUsers.Infra.Data.EntityConfiguration;

public class UserRolesConfiguration : IEntityTypeConfiguration<UserEntityRoles>
{
    public void Configure(EntityTypeBuilder<UserEntityRoles> builder)
    {
        builder.HasKey(it => it.Id);
        builder.Property(it => it.Roles).IsRequired();
        builder.Property(it => it.RequiredAddress).IsRequired();
        builder.Property(it => it.RequiredDocument).IsRequired();
        builder.Property(it => it.RequiredPhone).IsRequired();

        builder.HasOne(it => it.User)
               .WithOne(it => it.Role)
               .HasForeignKey<UserEntityRoles>(it => it.UserId);
    }
}
