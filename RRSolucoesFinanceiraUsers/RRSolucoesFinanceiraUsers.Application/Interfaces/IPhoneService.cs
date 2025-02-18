using RRSolucoesFinanceiraUsers.Application.DTOs;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IPhoneService
{
    Task<PhoneDTO> GetPhoneById(int? id);
}
