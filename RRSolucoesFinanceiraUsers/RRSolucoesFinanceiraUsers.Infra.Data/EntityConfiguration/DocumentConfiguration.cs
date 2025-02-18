using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RRSolucoesFinanceiraUsers.Domain.Entities;

namespace RRSolucoesFinanceiraUsers.Infra.Data.EntityConfiguration;

public class DocumentConfiguration : IEntityTypeConfiguration<DocumentEntity>
{
    public void Configure(EntityTypeBuilder<DocumentEntity> builder)
    {
        builder.HasKey(it => it.Id);
        builder.Property(it => it.DocumentType).IsRequired();
        builder.Property(it => it.NumberOfDocument).HasMaxLength(11).IsRequired();
        builder.Property(it => it.FilePath).IsRequired();
        builder.Property(it => it.DateUpload).IsRequired();
        
        builder.HasIndex(it => it.NumberOfDocument).IsUnique();

        builder.HasOne(it => it.User)
               .WithOne(it => it.Document)
               .HasForeignKey<DocumentEntity>(it => it.UserId);

    }
}
