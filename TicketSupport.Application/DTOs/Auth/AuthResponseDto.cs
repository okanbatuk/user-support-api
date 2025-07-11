namespace TicketSupport.Application.DTOs.Auth
{
  public class AuthResponseDto
  {
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string? Token { get; set; }
  }

}