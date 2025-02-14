using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Domain.Entities;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IUserService
{
    public Task<UserDTO> AddEmailAndIdInicial(Guid id, string? email, DateTime createdAt);
}
