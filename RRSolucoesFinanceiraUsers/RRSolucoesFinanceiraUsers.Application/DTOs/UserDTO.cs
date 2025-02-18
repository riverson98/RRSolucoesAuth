using System.ComponentModel.DataAnnotations;

namespace RRSolucoesFinanceiraUsers.Application.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    [Required(ErrorMessage = "The email is required")]
    public string? Email { get; set; }
    public DateOnly? BirthDate { get; set; }
    public char? Sex { get; set; }
    public string? PhotoPath { get; set; }
    public bool IsRegistrationComplete { get; set; }
    public DateTime? CreatedAt { get; set; }
    public AddressDTO? AddressDto { get; set; }
    public DocumentDTO DocumentDTO { get; set; }
    public IEnumerable<PhoneDTO?> PhonesDto { get; set; }
    public UserRolesDTO? UserRolesDto { get; set; }
}
