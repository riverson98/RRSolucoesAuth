using RRSolucoesFinanceiraUsers.Application.DTOs;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IUserService
{
    public Task<UserDTO> AddEmailAndIdInicial(Guid id, string? email, DateTime createdAt);
    public Task<UserDTO> GetUserById(Guid id);
}
