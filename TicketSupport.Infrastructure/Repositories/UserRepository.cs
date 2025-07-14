using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketSupport.Domain.Entities;
using TicketSupport.Domain.Interfaces.Repositories;
using TicketSupport.Infrastructure.Data;

namespace TicketSupport.Infrastructure.Repositories
{
  public class UserRepository : Repository<User>, IUserRepository
  {
    public UserRepository(AppDbContext context) : base(context, context.Set<User>())
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
      return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
    }
  }
}