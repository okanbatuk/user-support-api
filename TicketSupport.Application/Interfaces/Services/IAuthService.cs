using TicketSupport.Domain.Entities;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Application.Common;

namespace TicketSupport.Application.Interfaces.Services
{
  public interface IAuthService
  {
    Task<ApiResponse<AuthResponseDto>> Login(LoginDto loginDto);
    Task<ApiResponse<object>> Register(RegisterDto registerDto);
  }
}