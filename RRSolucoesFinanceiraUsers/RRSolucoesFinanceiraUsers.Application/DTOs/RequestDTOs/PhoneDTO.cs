using System.ComponentModel.DataAnnotations;

namespace RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;

public class PhoneDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The user id is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "The type of contact is required")]
    public string? TypeOfContact { get; set; }

    [Required(ErrorMessage = "The phone number is required")]
    public string? PhoneNumber { get; set; }
}
