using System.ComponentModel.DataAnnotations;

namespace R_RSolucoesFinanceirasAuth.Application.DTOs;

public class UserToRoleDTO
{
    [Required]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    public string? Role { get; set; }
}
