using TicketSupport.Domain.Enums;
using TicketSupport.Domain.Interfaces;

namespace TicketSupport.Domain.Entities
{
  public class Ticket : IHasUuid
  {
    public Guid Id { get; set; }
    public Guid Uuid { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public TicketStatus Status { get; set; } = TicketStatus.Open;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<TicketReply>? Replies { get; set; }
  }
}
