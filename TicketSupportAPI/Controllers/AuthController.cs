using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Application.Interfaces.Services;
using TicketSupport.Domain.Entities;

namespace TicketSupportAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController(IAuthService authService) : ControllerBase
  {
    private readonly IAuthService _authService = authService;

    [HttpPost("register")]
    public async Task<ActionResult<bool>> Register(RegisterDto registerDto)
    {
      return await _authService.Register(registerDto);
    }
  }
}