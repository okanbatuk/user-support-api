using FluentValidation;
using FluentValidation.AspNetCore;
using TicketSupport.Application.DTOs.Auth;
using TicketSupport.Application.Validators;

namespace TicketSupportAPI.Extensions
{
  public static class ValidationExtensions
  {
    public static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
      services
        .AddScoped<IValidator<RegisterDto>, RegisterDtoValidator>()
        .AddScoped<IValidator<LoginDto>, LoginDtoValidator>();

      services.AddFluentValidationAutoValidation();

      return services;
    }
  }
}