using Microsoft.AspNetCore.Mvc;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Application.Interfaces.Services;

namespace TicketSupportAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
      var result = await _authService.Register(registerDto);

      // Keep this check for future logging or custom header handling
      if (!result.Success) return StatusCode(result.StatusCode, result);
      return StatusCode(result.StatusCode, result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginDto loginDto)
    {
      var result = await _authService.Login(loginDto);

      // Keep this check for future logging or custom header handling
      if (!result.Success) return StatusCode(result.StatusCode, result);
      return StatusCode(result.StatusCode, result);
    }
  }
}