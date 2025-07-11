using Microsoft.EntityFrameworkCore;
using TicketSupport.Domain.Entities;

namespace TicketSupport.Infrastructure.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users => Set<User>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<TicketReply> TicketReplies => Set<TicketReply>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      foreach (var entity in builder.Model.GetEntityTypes())
      {
        var idProperty = entity.FindProperty("Id");
        if (idProperty?.ClrType == typeof(Guid))
        {
          idProperty.SetDefaultValueSql("uuid_generate_v4()");
          idProperty.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
        }
      }
    }

  }
}