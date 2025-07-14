using FluentValidation;
using TicketSupport.Application.DTOs.Auth;

namespace TicketSupport.Application.Validators
{
  public class RegisterDtoValidator : AbstractValidator<RegisterDto>
  {
    public RegisterDtoValidator()
    {
      RuleFor(x => x.Email)
          .NotEmpty().WithMessage("Email is required.")
          .EmailAddress().WithMessage("Invalid email format.");

      RuleFor(x => x.Password)
          .NotEmpty().WithMessage("Password is required.")
          .MinimumLength(6).WithMessage("Password must be at least 6 characters.");

      RuleFor(x => x.Name)
          .NotEmpty().WithMessage("Name is required.")
          .MinimumLength(3).WithMessage("Name must be at least 3 characters.");
    }
  }
}