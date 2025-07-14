using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using TicketSupport.Application.Exceptions;

namespace TicketSupportAPI.Extensions
{
  public static class ApiBehaviorOptionsExtensions
  {
    public static IServiceCollection ConfigureInvalidModelStateResponse(this IServiceCollection services)
    {
      services.Configure<ApiBehaviorOptions>(options =>
      {
        options.InvalidModelStateResponseFactory = context =>
        {
          var errors = context.ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .ToDictionary(
              kvp => kvp.Key,
              kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray() ?? Array.Empty<string>()
            );

          throw new ValidationException(errors);
        };
      });

      return services;
    }
  }
}
