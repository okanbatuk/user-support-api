using AutoMapper;
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
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMapper mapper)
    {
      _authService = authService;
      _mapper = mapper;
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
      if (!result.Success) return StatusCode(result.StatusCode, result);

      var responseDto = _mapper.Map<AuthResponseDto>(result.Data);
      responseDto.Token = null;

      return StatusCode(result.StatusCode, responseDto);
    }
  }
}