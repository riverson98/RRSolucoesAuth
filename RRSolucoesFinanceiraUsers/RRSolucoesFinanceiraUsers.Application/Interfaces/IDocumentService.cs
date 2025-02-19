using RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IDocumentService
{
    Task<DocumentDTO> GetDocumentById(int? id);
}
