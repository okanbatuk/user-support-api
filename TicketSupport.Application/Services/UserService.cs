using System;
using System.Threading.Tasks;
using TicketSupport.Application.Interfaces.Services;
using TicketSupport.Domain.Entities;
using TicketSupport.Domain.Interfaces.Repositories;

namespace TicketSupport.Application.Services
{
  public class UserService(IUserRepository userRepository) : IUserService
  {
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<IEnumerable<User>> GetAllAsync()
    {
      return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
      return await _userRepository.GetByEmailAsync(email);
    }

    public async Task<User?> GetByUuidAsync(Guid uuid)
    {
      return await _userRepository.GetByUuidAsync(uuid);
    }
  }
}