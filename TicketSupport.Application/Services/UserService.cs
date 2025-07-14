using System;
using System.Threading.Tasks;
using AutoMapper;
using TicketSupport.Application.Common;
using TicketSupport.Application.Common.Interfaces;
using TicketSupport.Application.DTOs.User;
using TicketSupport.Application.Interfaces;
using TicketSupport.Application.Interfaces.Services;
using TicketSupport.Domain.Interfaces.Repositories;

namespace TicketSupport.Application.Services
{
  public class UserService : IUserService
  {
    private readonly IUserRepository _userRepository;
    private readonly IApiResponseHelper _apiResponseHelper;
    private readonly IPasswordHasher _passwordHasher;

    private IMapper _mapper;

    public UserService(
      IMapper mapper,
      IApiResponseHelper apiResponseHelper,
      IUserRepository userRepository,
      IPasswordHasher passwordHasher)
    {
      _mapper = mapper;
      _apiResponseHelper = apiResponseHelper;
      _userRepository = userRepository;
      _passwordHasher = passwordHasher;
    }

    public async Task<ApiResponse<IEnumerable<UserDto>>> GetAllAsync()
    {
      var users = await _userRepository.GetAllAsync();
      if (users == null)
        return _apiResponseHelper.Fail<IEnumerable<UserDto>>("No users found", responseCode: "NOT_FOUND", statusCode: 404);

      var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
      return _apiResponseHelper.Success(userDtos, "Get All Users successfully", responseCode: "SUCCESS", statusCode: 200);
    }

    public async Task<ApiResponse<UserDto>> GetByEmailAsync(string email)
    {
      var user = await _userRepository.GetByEmailAsync(email);
      if (user == null)
        return _apiResponseHelper.Fail<UserDto>("User not found", responseCode: "NOT_FOUND", statusCode: 404);

      var userDto = _mapper.Map<UserDto>(user);
      return _apiResponseHelper.Success(userDto, "Get User successfully", responseCode: "SUCCESS", statusCode: 200);
    }

    public async Task<ApiResponse<UserDto>> GetByUuidAsync(Guid uuid)
    {
      var user = await _userRepository.GetByUuidAsync(uuid);
      if (user == null)
        return _apiResponseHelper.Fail<UserDto>("User not found", responseCode: "NOT_FOUND", statusCode: 404);

      var userDto = _mapper.Map<UserDto>(user);
      return _apiResponseHelper.Success(userDto, "Get User successfully", responseCode: "SUCCESS", statusCode: 200);
    }

    public async Task<ApiResponse<UserDto>> UpdateAsync(Guid uuid, UpdateUserDto updateUserDto)
    {
      var user = await _userRepository.GetByUuidAsync(uuid);
      if (user == null)
        return _apiResponseHelper.Fail<UserDto>("User not found", responseCode: "NOT_FOUND", statusCode: 404);

      if (!string.IsNullOrEmpty(updateUserDto.Name))
        user.Name = updateUserDto.Name;

      if (!string.IsNullOrEmpty(updateUserDto.Password))
      {
        _passwordHasher.HashPassword(updateUserDto.Password, out var hash, out var salt);
        user.PasswordHash = hash;
        user.PasswordSalt = salt;
      }

      _userRepository.Update(user);
      var saved = await _userRepository.SaveChangesAsync();
      if (!saved)
        return _apiResponseHelper.Fail<UserDto>("Update failed", responseCode: "INTERNAL_SERVER_ERROR", statusCode: 500);

      var updatedUserDto = _mapper.Map<UserDto>(user);
      return _apiResponseHelper.Success(updatedUserDto, "User updated successfully", responseCode: "SUCCESS", statusCode: 200);
    }

    public async Task<ApiResponse<object>> DeleteAsync(Guid uuid)
    {
      var user = await _userRepository.GetByUuidAsync(uuid);
      if (user == null)
        return _apiResponseHelper.Fail<object>("User not found", responseCode: "NOT_FOUND", statusCode: 404);

      _userRepository.Delete(user);
      var deleted = await _userRepository.SaveChangesAsync();
      if (deleted)
        return _apiResponseHelper.Success<object>("User deleted successfully", responseCode: "SUCCESS", statusCode: 200);
      return _apiResponseHelper.Fail<object>("Delete failed", responseCode: "INTERNAL_SERVER_ERROR", statusCode: 500);
    }

  }
}