using RRSolucoesFinanceiraUsers.Domain.Entities;

namespace RRSolucoesFinanceiraUsers.Domain.Interfaces;

public interface IUserEntityRepository
{
    public Task<UserEntity> AddEmailAndIdInicial(Guid id, string? email, DateTime createdAt);

    public Task<UserEntity?> GetUserWithDetailsAsync(Guid? id);
}
