using RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Domain.Entities;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using System.Linq.Expressions;

namespace RRSolucoesFinanceiraUsers.Application.Services;

public class PhoneService : IPhoneService
{

    private readonly IUnityOfWork<PhoneEntity> _unityOfWork;

    public PhoneService(IUnityOfWork<PhoneEntity> unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }

    public async Task<PhoneDTO> GetPhoneById(int? id)
    {
        Expression<Func<PhoneEntity, bool>> entityPredicate = it => it.Id.Equals(id);

        var phoneEntity = await _unityOfWork.Repository.GetAsync(entityPredicate);

        var phoneDto = new PhoneDTO
        {
            Id = phoneEntity!.Id,
            UserId = phoneEntity.UserId,
            PhoneNumber = phoneEntity.PhoneNumber,
            TypeOfContact = phoneEntity.TypeOfContact.ToString()
        };

        return phoneDto;
    }
}
