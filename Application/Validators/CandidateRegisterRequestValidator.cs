using Application.DTO.Candidate;
using FluentValidation;

namespace Application.Validators
{
    internal class CandidateRegisterRequestValidator : AbstractValidator<CandidateRegisterRequestDTO>
    {
        public CandidateRegisterRequestValidator()
        {
            RuleFor(c => c.FirstName)
                .NotNull()
                .MaximumLength(12)
                //Regex na duże litery i małe
                .Matches(@"^[a-zA-Z]+$");

            RuleFor(c => c.LastName)
                .NotNull()
                .MaximumLength(20)
                //Regex na duże litery i małe
                .Matches(@"^[a-zA-Z]+$");

            RuleFor(c => c.Region)
                .NotEmpty()
                .IsInEnum();

            RuleFor(c => c.City)
                .MaximumLength(25);
        }
    }
}
