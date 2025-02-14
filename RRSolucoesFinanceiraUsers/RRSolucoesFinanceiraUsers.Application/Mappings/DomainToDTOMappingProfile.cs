using AutoMapper;
using RRSolucoesFinanceiraUsers.Application.DTOs;
using RRSolucoesFinanceiraUsers.Domain.Entities;

namespace RRSolucoesFinanceiraUsers.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<AddressEntity, AddressDTO>().ReverseMap();
        CreateMap<DocumentEntity, DocumentDTO>().ReverseMap();
        CreateMap<PhoneEntity, PhoneDTO>().ReverseMap();
        CreateMap<UserEntity, UserDTO>().ReverseMap();
        CreateMap<UserEntityRoles, UserRolesDTO>().ReverseMap();
    }
}
