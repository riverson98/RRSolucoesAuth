using RRSolucoesFinanceiraUsers.Domain.Entities;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;

namespace RRSolucoesFinanceiraUsers.Infra.Data.Repository
{
    public class AddressEntityRepository : Repository<AddressEntity>, IAddressEntityRepository
    {
        public AddressEntityRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
