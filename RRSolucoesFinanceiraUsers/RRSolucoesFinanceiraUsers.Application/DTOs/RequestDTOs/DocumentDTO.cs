using System.ComponentModel.DataAnnotations;

namespace RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;

public class DocumentDTO
{
    public int? Id { get; set; }

    [Required(ErrorMessage = "The user id is required")]
    public Guid? UserId { get; set; }

    [Required(ErrorMessage = "The document type is required")]
    public string? DocumentType { get; set; }

    [Required(ErrorMessage = "The number of the document is required")]
    public string? NumberOfDocument { get; set; }
    public string? FilePath { get; set; }
}
