using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Domain.Entities;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using System.Linq.Expressions;

namespace RRSolucoesFinanceiraUsers.Application.Services;

public class UserRoleService : IUserRoleService
{
    private readonly IUnityOfWork<UserEntityRoles> _unityOfWork;

    public UserRoleService(IUnityOfWork<UserEntityRoles> unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public async Task<UserRolesDTO> GetUserRoleById(int? id)
    {
        Expression<Func<UserEntityRoles, bool>> entityPredicate = it => it.Id.Equals(id);

        var roleEntity = await _unityOfWork.Repository.GetAsync(entityPredicate);

        var roleDto = new UserRolesDTO
        {
            Id = roleEntity!.Id,
            RequiredAddress = roleEntity.RequiredAddress,
            RequiredDocument = roleEntity.RequiredDocument,
            RequiredPhone = roleEntity.RequiredPhone,
            Roles = roleEntity.Roles.ToString(),
            UserId = roleEntity.UserId,
        };

        return roleDto;
    }
}
