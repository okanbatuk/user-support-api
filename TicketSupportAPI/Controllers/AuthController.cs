using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Application.Interfaces.Services;
using TicketSupport.Application.Common.Interfaces;
using TicketSupport.Domain.Entities;

namespace TicketSupportAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController(IAuthService authService, IApiResponseHelper apiResponseHelper) : ControllerBase
  {
    private readonly IAuthService _authService = authService;
    private readonly IApiResponseHelper _apiResponseHelper = apiResponseHelper;

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