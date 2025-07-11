using System.Text;
using System.Security.Cryptography;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Application.Interfaces;
using TicketSupport.Application.Interfaces.Services;
using TicketSupport.Domain.Entities;
using TicketSupport.Domain.Interfaces.Repositories;

namespace TicketSupport.Application.Services
{
  public class AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher) : IAuthService
  {
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public async Task<AuthResponseDto?> Login(LoginDto loginDto)
    {
      /*       var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null) return false;
            return await _userRepository.LoGetUserByEmailgin(loginDto); */
      throw new NotImplementedException();
    }
    public async Task<bool> Register(RegisterDto registerDto)
    {
      var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
      if (existingUser != null) return false;

      _passwordHasher.HashPassword(registerDto.Password, out var hash, out var salt);

      var user = new User
      {
        Name = registerDto.Name,
        Email = registerDto.Email,
        PasswordHash = hash,
        PasswordSalt = salt
      };

      await _userRepository.AddAsync(user);
      return await _userRepository.SaveChangesAsync();
    }
  }
}
