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
        CreateMap<UserEntity, UserDTO>()
                 .ForMember(dest => dest.AddressDto, opt => opt.MapFrom(src => src.Address))
                 .ForMember(dest => dest.DocumentDTO, opt => opt.MapFrom(src => src.Document))
                 .ForMember(dest => dest.PhonesDto, opt => opt.MapFrom(src => src.Phones))
                 .ForMember(dest => dest.UserRolesDto, opt => opt.MapFrom(src => src.Role))
                 .ReverseMap();
        CreateMap<UserEntityRoles, UserRolesDTO>().ReverseMap();
    }
}
