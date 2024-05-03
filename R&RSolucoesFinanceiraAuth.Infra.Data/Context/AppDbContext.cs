using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using R_RSolucaoFinanceiraAuth.Domain.Entity;
using R_RSolucoesFinanceiraAuth.Infra.Data.Identity;

namespace R_RSolucoesFinanceiraAuth.Infra.Data.Context;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Owned(typeof(RefreshToken));
    }
}
