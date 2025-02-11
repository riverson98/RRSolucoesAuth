using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RRSolucoesFinanceiraUsers.Domain.Entities;

namespace RRSolucoesFinanceiraUsers.Infra.Data.EntityConfiguration;

public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.HasKey(it => it.Id);
        builder.Property(it => it.Street).HasMaxLength(100).IsRequired();
        builder.Property(it => it.Number).IsRequired();
        builder.Property(it => it.District).HasMaxLength(30).IsRequired();
        builder.Property(it => it.State).HasMaxLength(2).IsRequired();
        builder.Property(it => it.City).HasMaxLength(20).IsRequired();
        builder.Property(it => it.ZipCode).HasMaxLength(15).IsRequired();
        builder.Property(it => it.ProofOfResidencePath).IsRequired();
        builder.Property(it => it.DateUpload).IsRequired();
        
        builder.HasOne(it => it.User)
               .WithOne(it => it.Address)
               .HasForeignKey<AddressEntity>(it => it.UserId);
    }
}
