using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Domain.Entities;
using RRSolucoesFinanceiraUsers.Domain.Interfaces;
using System.Linq.Expressions;

namespace RRSolucoesFinanceiraUsers.Application.Services;

public class AddressService : IAddressService
{
    private readonly IUnityOfWork<AddressEntity> _unityOfWork;

    public AddressService(IUnityOfWork<AddressEntity> unityOfWork)
    {
        _unityOfWork = unityOfWork;
    }


    public async Task<AddressDTO> GetAddressById(int id)
    {
        Expression<Func<AddressEntity, bool>> entityPredicate = it => it.Id.Equals(id);

        var addressEntity = await _unityOfWork.Repository.GetAsync(entityPredicate);

        var addressDto = new AddressDTO
        {
            Id = addressEntity!.Id,
            UserId = addressEntity.UserId,
            City = addressEntity.City,
            District = addressEntity.District,
            Number = addressEntity.Number,
            State = addressEntity.State,
            Street = addressEntity.Street,
            ZipCode = addressEntity.ZipCode
        };

        return addressDto;
    }
}
