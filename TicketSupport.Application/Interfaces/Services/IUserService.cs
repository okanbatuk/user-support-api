using TicketSupport.Application.Common;
using TicketSupport.Application.DTOs.User;

namespace TicketSupport.Application.Interfaces.Services
{
  public interface IUserService
  {
    Task<ApiResponse<IEnumerable<UserDto>>> GetAllAsync();
    Task<ApiResponse<UserDto>> GetByUuidAsync(Guid uuid);
    Task<ApiResponse<UserDto>> GetByEmailAsync(string email);
    Task<ApiResponse<UserDto>> UpdateAsync(Guid uuid, UpdateUserDto updateUserDto);

    Task<ApiResponse<object>> DeleteAsync(Guid uuid);
  }
}