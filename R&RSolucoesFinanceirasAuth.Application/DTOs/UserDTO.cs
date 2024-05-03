using System.ComponentModel.DataAnnotations;

namespace R_RSolucoesFinanceirasAuth.Application.DTOs;

public class UserDTO
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Senhas não confere")]
    public string? ConfirmPassword { get; set; }
}
