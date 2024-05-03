using System.ComponentModel.DataAnnotations;

namespace R_RSolucoesFinanceirasAuth.Application.DTOs;

public class TokenRequestDTO
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
