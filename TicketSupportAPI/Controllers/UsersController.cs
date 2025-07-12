using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSupport.Application.DTOs.User;
using TicketSupport.Application.Interfaces.Services;
using TicketSupport.Domain.Entities;

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
      var users = await _userService.GetAllAsync();
      return Ok(users.Select(u => new UserDto
      {
        UserId = u.Uuid,
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
        UserId = user.Uuid,
        Name = user.Name,
        Email = user.Email
      });
    }
  }
}
