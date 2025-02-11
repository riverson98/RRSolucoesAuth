using RRSolucoesFinanceiraUsers.Domain.Enums;
using RRSolucoesFinanceiraUsers.Domain.Validation;

namespace RRSolucoesFinanceiraUsers.Domain.Entities;

public sealed class DocumentEntity
{
    public int Id { get; }
    public int? UserId { get; private set; }
    public UserEntity User { get; private set; }
    public DocumentType DocumentType { get; private set; }
    public string? NumberOfDocument { get; private set; }
    public string? FilePath { get; private set; }
    public DateTime DateUpload { get; private set; }

    public DocumentEntity()
    {
        
    }
    public DocumentEntity(int id, string numberOfDocument, string filePath, DocumentType documentType)
    {
        DomainExceptionValidation.When(id < 0, "Invalid value for id");
        Id = id;
        ValidateDomain(numberOfDocument, filePath, documentType);
    }

    public DocumentEntity(string numberOfDocument, string filePath, DocumentType documentType)
    {
        ValidateDomain(numberOfDocument, filePath, documentType);
    }

    public void Update(string numberOfDocument, string filePath, int? userId, DocumentType documentType)
    {
        ValidateDomain(numberOfDocument, filePath, documentType);
        UserId = userId;
    }

    private void ValidateDomain(string numberOfDocument, string filePath, DocumentType documentType)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(numberOfDocument),
            "The number of document is required");

        DomainExceptionValidation.When(string.IsNullOrEmpty(filePath),
            "The file path is required");
            
        DomainExceptionValidation.When(numberOfDocument.Length > 11,
            "The number of the document must have 11 characters");

        DomainExceptionValidation.When(filePath.Length > 255,
            "the file path is too large");
        
        DomainExceptionValidation.When(documentType < 0,
            "Invalid value for document type");

        NumberOfDocument = numberOfDocument;
        FilePath = filePath;
        DateUpload = DateTime.Now;
        DocumentType = documentType;
    }
}
