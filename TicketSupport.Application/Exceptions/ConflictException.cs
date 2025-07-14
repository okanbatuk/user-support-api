namespace TicketSupport.Application.Exceptions
{
  public class ConflictException : Exception
  {
    public ConflictException() : base("Conflict occurred.") { }
    public ConflictException(string message) : base(message) { }
  }
}