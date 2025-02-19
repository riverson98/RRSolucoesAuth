using System.ComponentModel.DataAnnotations;

namespace RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;

public class AddressDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The user id is required")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "The street is required")]
    public string? Street { get; set; }

    [Required(ErrorMessage = "The number is required")]
    public int? Number { get; set; }

    [Required(ErrorMessage = "The district is required")]
    public string? District { get; set; }

    [Required(ErrorMessage = "The state is required")]
    public string? State { get; set; }

    [Required(ErrorMessage = "The city is required")]
    public string? City { get; set; }

    [Required(ErrorMessage = "The zip code is required")]
    public string? ZipCode { get; set; }

    public string? ProofOfResidencePath { get; set; }
}
