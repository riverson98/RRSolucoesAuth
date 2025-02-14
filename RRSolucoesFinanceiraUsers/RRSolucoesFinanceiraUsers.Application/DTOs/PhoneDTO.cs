using RRSolucoesFinanceiraUsers.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RRSolucoesFinanceiraUsers.Application.DTOs;

public class PhoneDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The user id is required")]
    public int Guid { get; set; }

    [Required(ErrorMessage = "The type of contact is required")]
    public TypeOfContact TypeOfContact { get; set; }

    [Required(ErrorMessage = "The phone number is required")]
    public string? PhoneNumber { get; set; }
    public UserDTO? UserDto { get; set; }
}
