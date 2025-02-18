using RRSolucoesFinanceiraUsers.Application.DTOs;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IAddressService
{
    Task<AddressDTO> GetAddressById(int id);
}
