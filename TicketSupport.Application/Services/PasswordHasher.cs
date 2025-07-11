using System.Text;
using System.Security.Cryptography;
using TicketSupport.Application.Interfaces;

namespace TicketSupport.Application.Services
{
  public class PasswordHasher : IPasswordHasher
  {
    public void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using var hmac = new System.Security.Cryptography.HMACSHA512();
      passwordSalt = hmac.Key;
      passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
    {
      using var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt);
      var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      return computedHash.SequenceEqual(storedHash);
    }
  }
}