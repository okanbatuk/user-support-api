using TicketSupport.Domain.Entities;

namespace TicketSupport.Application.Interfaces.Services
{
  public interface IUserService
  {
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByUuidAsync(Guid uuid);
    Task<User?> GetByEmailAsync(string email);
  }
}