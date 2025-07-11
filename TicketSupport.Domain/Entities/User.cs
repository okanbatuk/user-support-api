using TicketSupport.Domain.Enums;
using TicketSupport.Domain.Interfaces;

namespace TicketSupport.Domain.Entities
{
  public class User : IHasUuid
  {
    public Guid Id { get; set; }
    public Guid Uuid { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public UserRole Role { get; set; } = UserRole.User;

    public ICollection<Ticket>? Tickets { get; set; }
    public ICollection<TicketReply>? Replies { get; set; }
  }
}