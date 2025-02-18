using RRSolucoesFinanceiraUsers.Application.DTOs;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IDocumentService
{
    Task<DocumentDTO> GetDocumentById(int? id);
}
