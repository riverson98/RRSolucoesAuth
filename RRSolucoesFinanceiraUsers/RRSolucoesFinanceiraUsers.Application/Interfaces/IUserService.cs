using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IUserService
{
    public Task<UserDto> AddEmailAndIdInicial(Guid id, string? email);
    public Task<UserDto> GetUserById(Guid id);
    public Task<UserWithDetailsDTO> GetUserWithDetailsAsync(Guid id);
}
