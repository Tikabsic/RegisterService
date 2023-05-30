using Application.DTO;
using Application.DTO.Candidate;
using Application.DTO.Recruiter;
using Application.Interfaces;
using Application.Services.ServiceHelpers;
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

        public async Task RegisterCandidate(CandidateRegisterRequestDTO request)
        {
            await _registerHelper.SendCandidateDataToUserService(request);
            await _registerHelper.SendCredentialsToLoginService(request);
            await Task.CompletedTask;
        }

        public async Task RegisterRecruiter(RecruiterRegisterRequestDTO request)
        {
            await _registerHelper.SendRecruiterDataToUserService(request);
            await _registerHelper.SendCredentialsToLoginService(request);
            await Task.CompletedTask;
        }
    }
}
