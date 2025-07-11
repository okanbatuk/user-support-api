using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSupport.Infrastructure.Data;

namespace TicketSupportAPI.Extensions
{
  public static class DbContextExtensions
  {
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
      var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

      services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(connectionString));

      return services;
    }
  }
}