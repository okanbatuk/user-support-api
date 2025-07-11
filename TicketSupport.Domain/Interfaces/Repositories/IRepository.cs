using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketSupport.Domain.Interfaces.Repositories
{
  public interface IRepository<T> where T : class, IHasUuid
  {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByUuidAsync(Guid uuid);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> SaveChangesAsync();
  }
}