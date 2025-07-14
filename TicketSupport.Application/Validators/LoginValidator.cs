using FluentValidation;
using TicketSupport.Application.DTOs.Auth;

namespace TicketSupport.Application.Validators
{
  public class LoginDtoValidator : AbstractValidator<LoginDto>
  {
    public LoginDtoValidator()
    {
      RuleFor(x => x.Email)
          .NotEmpty().WithMessage("Email is required.")
          .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Invalid email format.");

      RuleFor(x => x.Password)
          .NotEmpty().WithMessage("Password is required.");
    }
  }
}
