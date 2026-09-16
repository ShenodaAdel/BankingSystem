using BankingSystem.Application.Services.Auth.Dtos;
using FluentValidation;

namespace BankingSystem.Application.Validators.AuthValidator
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(100);

            RuleFor(r => r.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(100);

            RuleFor(r => r.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(256)
                .EmailAddress().WithMessage("Email format is not valid.");

            RuleFor(r => r.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
                .MaximumLength(128)
                .Matches("[A-Z]").WithMessage("Password must contain an uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain a lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain a digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain a symbol.");

            RuleFor(r => r.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20)
                .Matches(@"^[0-9+\-\s()]+$").WithMessage("Phone number format is not valid.");
        }
    }
}
