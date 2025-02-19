using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;

public class UserDto
{
    [Required(ErrorMessage = "The id is required")]
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "The name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "The birth date is required")]
    public DateOnly? BirthDate { get; set; }

    [Required(ErrorMessage = "The gender is required")]
    public string? Sex { get; set; }
    public string? PhotoPath { get; set; }
    public bool IsRegistrationComplete { get; set; }
    public DateTime? CreatedAt { get; set; }

    [JsonIgnore]
    public AddressDTO? AddressDto { get; set; }

    [JsonIgnore]
    public DocumentDTO? DocumentDTO { get; set; }

    [JsonIgnore]
    public IEnumerable<PhoneDTO?>? PhonesDto { get; set; }

    [JsonIgnore]
    public UserRolesDTO? UserRolesDto { get; set; }
}
