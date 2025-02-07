using System.ComponentModel.DataAnnotations;

namespace R_RSolucoesFinanceirasAuth.Application.DTOs
{
    public class RoleDTO
    {
        [Required]
        public string? Name { get; set; }
    }
}
