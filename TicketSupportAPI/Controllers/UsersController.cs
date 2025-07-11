using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSupport.Application.DTOs.User;
using TicketSupport.Application.Interfaces.Services;

namespace TicketSupportAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController(IUserService userService) : ControllerBase
  {
    private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
    {
      var users = await _userService.GetAllAsync();
      return Ok(users.Select(u => new UserDto
      {
        Name = u.Name,
        Email = u.Email
      }));
    }

    [HttpGet("{uuid}")]
    public async Task<ActionResult<UserDto>> GetUser(Guid uuid)
    {
      var user = await _userService.GetByUuidAsync(uuid);
      if (user == null)
        return NotFound();

      return Ok(new UserDto
      {
        Name = user.Name,
        Email = user.Email
      });
    }
  }
}
