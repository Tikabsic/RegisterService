using Application.DTO;
using FluentValidation;

namespace Application.Validators
{
    internal class RegisterRequestValidator : AbstractValidator<BaseDTO>
    {
        public RegisterRequestValidator()
        {
            RuleFor(c => c.Email)
                .EmailAddress()
                .NotNull();

            RuleFor(c => c.Password)
                //Regex na duże litery, małe i cyfry
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).*$")
                .NotNull()
                .MinimumLength(8)
                .MaximumLength(16);

            RuleFor(c => c.ConfirmPassword)
                .Matches(c => c.Password);
        }
    }
}
