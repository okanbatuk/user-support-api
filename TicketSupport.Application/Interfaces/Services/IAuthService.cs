using TicketSupport.Application.Common;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Domain.Entities;

namespace TicketSupport.Application.Interfaces.Services
{
  public interface IAuthService
  {
    Task<ApiResponse<object>> Register(RegisterDto registerDto);
    Task<ApiResponse<User>> Login(LoginDto loginDto);
  }
}