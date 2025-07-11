using TicketSupport.Domain.Entities;
using TicketSupport.Application.DTOs.Auth;

namespace TicketSupport.Application.Interfaces.Services
{
  public interface IAuthService
  {
    Task<AuthResponseDto?> Login(LoginDto loginDto);
    Task<bool> Register(RegisterDto registerDto);
  }
}