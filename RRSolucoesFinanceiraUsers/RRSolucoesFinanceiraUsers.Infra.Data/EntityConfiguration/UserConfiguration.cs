using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RRSolucoesFinanceiraUsers.Domain.Entities;

namespace RRSolucoesFinanceiraUsers.Infra.Data.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(it => it.Id);
        builder.Property(it => it.Id).ValueGeneratedNever();
        builder.Property(it => it.Name).HasMaxLength(60);
        builder.Property(it => it.Email).HasMaxLength(60).IsRequired();
        builder.Property(it => it.BirthDate);
        builder.Property(it => it.Sex).HasMaxLength(1);
        builder.Property(it => it.PhotoPath);
        builder.Property(it => it.RegistrationDate);
    }
}
