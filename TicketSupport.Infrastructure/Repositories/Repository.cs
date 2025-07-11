using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketSupport.Domain.Interfaces;
using TicketSupport.Domain.Interfaces.Repositories;
using TicketSupport.Infrastructure.Data;

namespace TicketSupport.Infrastructure.Repositories
{
  public class Repository<T> : IRepository<T> where T : class, IHasUuid
  {
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context, DbSet<T> dbSet)
    {
      _context = context;
      _dbSet = dbSet;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByUuidAsync(Guid uuid)
    {
      return await _dbSet.FirstOrDefaultAsync(e => e.Uuid == uuid);
    }

    public async Task AddAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
      _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
      _dbSet.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
  }
}