using System.Threading.Tasks;
using TicketSupport.Domain.Entities;

namespace TicketSupport.Domain.Interfaces.Repositories
{
  public interface IUserRepository : IRepository<User>
  {
    Task<User?> GetByEmailAsync(string email);
  }
}