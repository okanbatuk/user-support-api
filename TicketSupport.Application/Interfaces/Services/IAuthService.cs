using TicketSupport.Application.Common;
using TicketSupport.Application.DTOs.Auth;

namespace TicketSupport.Application.Interfaces.Services
{
  public interface IAuthService
  {
    Task<ApiResponse<AuthResponseDto>> Login(LoginDto loginDto);
    Task<ApiResponse<object>> Register(RegisterDto registerDto);
  }
}