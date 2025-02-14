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

    public async Task<ResponseDTO> RegisterAsync(UserDTO userDto)
    {
        var response = new ResponseDTO();
        var userEntity = _mapper.Map<User>(userDto);
        var result = await _userRepository.RegisterAsync(userEntity);

        if (result.GetSuccess())
        {
            var requestToken = new TokenRequest(userEntity.Email, userEntity.Password);
            var authEntity = await _userRepository.GenerateAccessTokenAsync(requestToken);

            response.Id = result.Id;
            response.Email = result.Email;
            response.Token = authEntity.Token;
            response.RefreshToken = authEntity.RefreshToken;
            response.Success = true;
            response.CreatedAt = result.CreatedAt;
            response.IsRegistrationCompleted = authEntity.IsRegistrationCompleted;

            return response;
        }

        foreach (var erro in result.GetErrors())
        {
            response.Errors.Add(erro);
        }

        return response;
    }
}
