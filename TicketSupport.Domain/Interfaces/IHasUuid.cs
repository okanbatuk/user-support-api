using System;

namespace TicketSupport.Domain.Interfaces
{
  public interface IHasUuid
  {
    public Guid Uuid { get; }
  }
}