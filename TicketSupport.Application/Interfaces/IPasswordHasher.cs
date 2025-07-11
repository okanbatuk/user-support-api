namespace TicketSupport.Application.Interfaces
{
  public interface IPasswordHasher
  {
    public void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
    public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
  }
}