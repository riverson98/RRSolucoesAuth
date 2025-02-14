using RRSolucoesFinanceiraUsers.Domain.Entities;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;

namespace RRSolucoesFinanceiraUsers.Infra.Data.Repository;

public class UserEntityRepository : Repository<UserEntity>, IUserEntityRepository
{
    public UserEntityRepository(ApplicationDBContext context) : base(context)
    {
    }

    public async Task<UserEntity> AddEmailAndIdInicial(Guid id, string? email, DateTime createdAt)
    {
        var userEntity = new UserEntity(email!, id, createdAt);
        _context.Add(userEntity);
        return userEntity;  
    }
}
