using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Domain.Entities;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using System.Linq.Expressions;

namespace RRSolucoesFinanceiraUsers.Application.Services;

public class DocumentService : IDocumentService
{
    private readonly IUnityOfWork<DocumentEntity> _unityOfWork;

    public DocumentService(IUnityOfWork<DocumentEntity> unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public async Task<DocumentDTO> GetDocumentById(int? id)
    {
        Expression<Func<DocumentEntity, bool>> entityPredicate = it => it.Id.Equals(id);

        var docEntity = await _unityOfWork.Repository.GetAsync(entityPredicate);

        var docDto = new DocumentDTO
        {
            Id = docEntity?.Id,
            DocumentType = docEntity?.DocumentType.ToString(),
            NumberOfDocument = docEntity?.NumberOfDocument,
            FilePath = docEntity?.FilePath,
            UserId = docEntity?.UserId
        };

        return docDto;
    }
}
