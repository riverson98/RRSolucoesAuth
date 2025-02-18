using System.ComponentModel.DataAnnotations;

namespace RRSolucoesFinanceiraUsers.Application.DTOs;

public class UserRolesDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The role is required")]
    public string? Roles { get; set; }

    [Required(ErrorMessage = "The required address most have be informed")]
    public bool RequiredAddress { get; set; }

    [Required(ErrorMessage = "The required phone most have be informed")]
    public bool RequiredPhone { get; set; }

    [Required(ErrorMessage = "The required document most have be informed")]
    public bool RequiredDocument { get; set; }

    [Required(ErrorMessage = "The user id is required")]
    public Guid UserId { get; set; }
}
