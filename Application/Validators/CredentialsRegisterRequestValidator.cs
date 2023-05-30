using Application.DTO;
using FluentValidation;

namespace Application.Validators
{
    internal class CredentialsRegisterRequestValidator : AbstractValidator<BaseDTO>
    {
        public CredentialsRegisterRequestValidator()
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
