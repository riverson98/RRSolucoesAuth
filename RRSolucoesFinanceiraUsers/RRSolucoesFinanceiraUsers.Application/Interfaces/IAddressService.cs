using RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IAddressService
{
    Task<AddressDTO> GetAddressById(int id);
}
