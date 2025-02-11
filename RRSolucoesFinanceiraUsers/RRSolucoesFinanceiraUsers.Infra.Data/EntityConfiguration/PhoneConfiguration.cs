using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RRSolucoesFinanceiraUsers.Domain.Entities;

namespace RRSolucoesFinanceiraUsers.Infra.Data.EntityConfiguration;

public class PhoneConfiguration : IEntityTypeConfiguration<PhoneEntity>
{
    public void Configure(EntityTypeBuilder<PhoneEntity> builder)
    {
        builder.HasKey(it => it.Id);
        builder.Property(it => it.TypeOfContact).IsRequired();
        builder.Property(it => it.PhoneNumber).HasMaxLength(12).IsRequired();

        builder.HasOne(it => it.User)
               .WithMany(it => it.Phones)
               .HasForeignKey(it => it.UserId);
    }
}
