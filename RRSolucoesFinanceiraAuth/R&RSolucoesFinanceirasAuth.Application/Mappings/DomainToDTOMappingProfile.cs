using AutoMapper;
using R_RSolucaoFinanceiraAuth.Domain.Entity;
using R_RSolucoesFinanceirasAuth.Application.DTOs;

namespace R_RSolucoesFinanceirasAuth.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<Authentication, AuthenticationDTO>().ReverseMap();
        CreateMap<TokenRequest, TokenRequestDTO>().ReverseMap();
        CreateMap<UserToRole, UserToRoleDTO>().ReverseMap();
    }
}
