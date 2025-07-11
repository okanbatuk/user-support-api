using TicketSupport.Domain.Interfaces;

namespace TicketSupport.Domain.Entities;

public class TicketReply : IHasUuid
{
  public Guid Id { get; set; }
  public Guid Uuid { get; set; } = Guid.NewGuid();

  public string Message { get; set; } = null!;
  public DateTime CreatedAt { get; set; }

  public Guid TicketId { get; set; }
  public Ticket Ticket { get; set; } = null!;
  public Guid RepliedBy { get; set; }
  public User Replier { get; set; } = null!;
}
