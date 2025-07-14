using System.Text;
using AutoMapper;
using TicketSupport.Application.Common;
using TicketSupport.Application.Common.Interfaces;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Application.Exceptions;
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

    private readonly IMapper _mapper;


    public AuthService(
      IUserRepository userRepository,
      IPasswordHasher passwordHasher,
      IApiResponseHelper apiResponseHelper,
      IMapper mapper)
    {
      _userRepository = userRepository;
      _passwordHasher = passwordHasher;
      _apiResponseHelper = apiResponseHelper;
      _mapper = mapper;
    }

    public async Task<ApiResponse<object>> Register(RegisterDto registerDto)
    {
      var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
      if (existingUser != null) throw new ConflictException("User already exists.");

      _passwordHasher.HashPassword(registerDto.Password, out var hash, out var salt);
      var user = _mapper.Map<User>(registerDto);
      user.PasswordHash = hash;
      user.PasswordSalt = salt;

      await _userRepository.AddAsync(user);

      var created = await _userRepository.SaveChangesAsync();
      if (!created)
        throw new Exception("Something went wrong.");

      return _apiResponseHelper.Success<object>("User registered successfully", responseCode: "CREATED", statusCode: 201);
    }

    public async Task<ApiResponse<User>> Login(LoginDto loginDto)
    {
      var user = await _userRepository.GetByEmailAsync(loginDto.Email);
      if (user == null || !_passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash, user.PasswordSalt))
        throw new UnauthorizedException("Invalid email or password.");

      return _apiResponseHelper.Success(user, "Login successfully", responseCode: "SUCCESS", statusCode: 200);
    }
  }
}
