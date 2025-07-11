using Microsoft.Extensions.DependencyInjection;
using TicketSupport.Application.Services;
using TicketSupport.Application.Interfaces;
using TicketSupport.Application.Interfaces.Services;
using TicketSupport.Application.Common.Helpers;
using TicketSupport.Application.Common.Interfaces;
using TicketSupport.Domain.Interfaces.Repositories;
using TicketSupport.Infrastructure.Data;
using TicketSupport.Infrastructure.Repositories;

namespace TicketSupportAPI.Extensions
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IAuthService, AuthService>();
      services.AddScoped<IPasswordHasher, PasswordHasher>();
      services.AddSingleton<IApiResponseHelper, ApiResponseHelper>();


      return services;
    }
  }
}
