using RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;

namespace RRSolucoesFinanceiraUsers.Application.Interfaces;

public interface IPhoneService
{
    Task<PhoneDTO> GetPhoneById(int? id);
}
