using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSupport.Application.DTOs.User;
using TicketSupport.Application.Interfaces.Services;

namespace TicketSupportAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
    {
      var result = await _userService.GetAllAsync();
      if (!result.Success) return StatusCode(result.StatusCode, result);
      return StatusCode(result.StatusCode, result);
    }

    [HttpGet("{uuid}")]
    public async Task<ActionResult<UserDto>> GetUser(Guid uuid)
    {
      var result = await _userService.GetByUuidAsync(uuid);
      if (!result.Success)
        return StatusCode(result.StatusCode, result);
      return StatusCode(result.StatusCode, result);
    }

    [HttpPost("{uuid}")]
    public async Task<ActionResult<UserDto>> UpdateUser(Guid uuid, UpdateUserDto updateUserDto)
    {
      var result = await _userService.UpdateAsync(uuid, updateUserDto);
      if (!result.Success)
        return StatusCode(result.StatusCode, result);
      return StatusCode(result.StatusCode, result);
    }

    [HttpDelete("{uuid}")]
    public async Task<IActionResult> DeleteUser(Guid uuid)
    {
      var result = await _userService.DeleteAsync(uuid);
      if (!result.Success)
        return StatusCode(result.StatusCode, result);
      return StatusCode(result.StatusCode, result);
    }
  }
}
