using RRSolucoesFinanceiraUsers.Domain.Entities;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;

namespace RRSolucoesFinanceiraUsers.Infra.Data.Repository;

public class DocumentEntityRepository : Repository<DocumentEntity>, IDocumentEntityRepository
{
    public DocumentEntityRepository(ApplicationDBContext context) : base(context)
    {
    }
}
