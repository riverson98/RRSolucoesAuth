using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;

namespace RRSolucoesFinanceiraUsers.Infra.Data.Repository;

public class UserEntityRolesRepository : Repository<UserEntityRepository>, IUserEntityRolesRepository
{
    public UserEntityRolesRepository(ApplicationDBContext context) : base(context)
    {
    }
}
