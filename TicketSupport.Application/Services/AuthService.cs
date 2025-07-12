using System.Text;
using System.Security.Cryptography;
using TicketSupport.Application.Common;
using TicketSupport.Application.Common.Interfaces;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Application.Interfaces;
using TicketSupport.Application.Interfaces.Services;
using TicketSupport.Domain.Entities;
using TicketSupport.Domain.Interfaces.Repositories;

namespace TicketSupport.Application.Services
{
  public class AuthService : IAuthService
  {
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IApiResponseHelper _apiResponseHelper;

    public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, IApiResponseHelper apiResponseHelper)
    {
      _userRepository = userRepository;
      _passwordHasher = passwordHasher;
      _apiResponseHelper = apiResponseHelper;
    }

    public async Task<ApiResponse<AuthResponseDto>> Login(LoginDto loginDto)
    {
      var user = await _userRepository.GetByEmailAsync(loginDto.Email);
      if (user == null || !_passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash, user.PasswordSalt))
        return _apiResponseHelper.Fail<AuthResponseDto>("Invalid credentials", responseCode: "UNAUTHORIZED", statusCode: 401);

      var response = new AuthResponseDto
      {
        UserId = user.Uuid,
        Name = user.Name,
        Email = user.Email,
        Role = user.Role.ToString(),
        Token = null
      };
      return _apiResponseHelper.Success<AuthResponseDto>(response, "Login successful", responseCode: "SUCCESS", statusCode: 200);
    }
    public async Task<ApiResponse<object>> Register(RegisterDto registerDto)
    {
      var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
      if (existingUser != null) return _apiResponseHelper.Fail<object>("User already exists", responseCode: "CONFLICT", statusCode: 409);

      _passwordHasher.HashPassword(registerDto.Password, out var hash, out var salt);

      var user = new User
      {
        Name = registerDto.Name,
        Email = registerDto.Email,
        PasswordHash = hash,
        PasswordSalt = salt
      };

      var created = await _userRepository.CreateAsync(user);
      if (!created)
        return _apiResponseHelper.Fail<object>("Registration failed", responseCode: "INTERNAL_SERVER_ERROR", statusCode: 500);

      return _apiResponseHelper.Success<object>("User registered successfully", responseCode: "CREATED", statusCode: 201);
    }
  }
}
