using Application.DTO;
using Application.DTO.Candidate;
using Application.DTO.Recruiter;
using Application.Interfaces;
using Application.Services.ServiceHelpers;
using Application.Validators;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class RegisterService : IRegisterService
    {
        private readonly RegisterHelper _registerHelper;

        public RegisterService(RegisterHelper registerHelper)
        {
            _registerHelper = registerHelper;
        }

        private bool CandidateValidate(CandidateRegisterRequestDTO dto)
        {
            var validator = new CandidateRegisterRequestValidator();
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                return true;
            }

            return false;
        }

        private bool RecruiterValidate(RecruiterRegisterRequestDTO dto)
        {
            var validator = new RecruiterRegisterRequestValidator();
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                return true;
            }

            return false;
        }

        private bool CredentialsValidate(BaseDTO dto)
        {
            var validator = new CredentialsRegisterRequestValidator();
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                return true;
            }

            return false;
        }

        public async Task RegisterCandidate(CandidateRegisterRequestDTO request)
        {
            if (!CredentialsValidate(request) || !CandidateValidate(request))
            {
                throw new Exception("Something went wrong.");
            }

            await _registerHelper.SendCandidateDataToUserService(request);
            await _registerHelper.SendCredentialsToLoginService(request);
            await Task.CompletedTask;
        }

        public async Task RegisterRecruiter(RecruiterRegisterRequestDTO request)
        {
            if (!CredentialsValidate(request) || !RecruiterValidate(request))
            {
                throw new Exception("Something went wrong.");
            }

            await _registerHelper.SendCredentialsToLoginService(request);
            await _registerHelper.SendRecruiterDataToUserService(request);
            await Task.CompletedTask;

        }
    }
}
