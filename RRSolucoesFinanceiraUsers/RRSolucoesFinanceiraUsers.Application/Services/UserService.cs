using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Domain.Entities;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using System.Linq.Expressions;

namespace RRSolucoesFinanceiraUsers.Application.Services;

public class UserService : IUserService
{
    private readonly IUnityOfWork<UserEntity> _unityOfWork;

    public UserService(IUnityOfWork<UserEntity> unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public async Task<UserDTO> AddEmailAndIdInicial(Guid id, string? email, DateTime createdAt)
    {

        var entityAdded = _unityOfWork.UserEntityRepository.AddEmailAndIdInicial(id, email, createdAt);
        await _unityOfWork.CommitAsync();
        var userDto = new UserDTO
        {
            Id = entityAdded.Result.Id,
            Email = entityAdded.Result.Email,
            CreatedAt = entityAdded.Result.RegistrationDate
        };

        return userDto;
    }

    public async Task<UserDTO> GetUserById(Guid id)
    {
        Expression<Func<UserEntity, bool>> entityPredicate = it => it.Id.Equals(id);
         
        var userEntity = await _unityOfWork.Repository.GetAsync(entityPredicate);

        var userDto = new UserDTO
        {
            Id = userEntity.Id,
            IsRegistrationComplete = userEntity.IsRegistrationComplete
        };
        
        return userDto;
    }
}
