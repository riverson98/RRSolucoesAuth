using AutoMapper;
using R_RSolucaoFinanceiraAuth.Domain.Entity;
using R_RSolucaoFinanceiraAuth.Domain.Interface;
using R_RSolucoesFinanceirasAuth.Application.DTOs;
using R_RSolucoesFinanceirasAuth.Application.Interfaces;

namespace R_RSolucoesFinanceirasAuth.Application.Services;

public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<string> AddRoleAsync(UserToRoleDTO userToRoleDto)
    {
        var userToRoleEntity = _mapper.Map<UserToRole>(userToRoleDto);
        return await _userRepository.AddRoleAsync(userToRoleEntity);
    }

    public async Task<AuthenticationDTO> GetTokenAsync(TokenRequestDTO requestDto)
    {
        var requestEntity = _mapper.Map<TokenRequest>(requestDto);
        var authentication = await _userRepository.GenerateAccessTokenAsync(requestEntity);
        return _mapper.Map<AuthenticationDTO>(authentication);
    }

    public async Task<AuthenticationDTO> RefreshTokenAsync(string token)
    {
        var authEntity = await _userRepository.RefreshTokenAsync(token);
        return _mapper.Map<AuthenticationDTO>(authEntity);
    }

    public async Task<string> RegisterAsync(UserDTO userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);
        return await _userRepository.RegisterAsync(userEntity);
    }
}
