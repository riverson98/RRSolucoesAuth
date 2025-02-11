using RRSolucoesFinanceiraUsers.Domain.Entities;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;

namespace RRSolucoesFinanceiraUsers.Infra.Data.Repository;

public class PhoneEntityRepository : Repository<PhoneEntity>, IPhoneEntityRepository
{
    public PhoneEntityRepository(ApplicationDBContext context) : base(context)
    {
    }
}
