using Application.DTO.Candidate;
using Application.DTO.Recruiter;
using Application.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    internal class RecruiterRegisterRequestValidator : AbstractValidator<RecruiterRegisterRequestDTO>
    {
        public RecruiterRegisterRequestValidator()
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

            RuleFor(c => c.Company)
                .NotEmpty();

            RuleFor(c => c.CompanyAddress)
                .NotEmpty();

            RuleFor(c => c.CompanyRegion)
                .IsInEnum()
                .NotEmpty();
        }
    }
}
