using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;

namespace RRSolucoesFinanceiraUsers.Application.Services;

public class UserService : IUserService
{
    private readonly IUnityOfWork<UserDTO> _unityOfWork;

    public UserService(IUnityOfWork<UserDTO> unityOfWork)
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
}
