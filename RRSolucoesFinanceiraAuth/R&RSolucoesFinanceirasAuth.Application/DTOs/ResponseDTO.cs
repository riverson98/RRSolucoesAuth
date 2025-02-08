namespace R_RSolucoesFinanceirasAuth.Application.DTOs;

public class ResponseDTO
{
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public bool Success { get; set; }
    public List<string>? Errors { get; set; } = new List<string>();
}
