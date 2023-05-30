using Application.DTO;
using Application.DTO.Candidate;
using Application.DTO.Recruiter;
using Application.Producers;
using AutoMapper;

namespace Application.Services.ServiceHelpers
{
    internal class RegisterHelper
    {
        private readonly IMapper _mapper;

        public RegisterHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        internal async Task SendCandidateDataToUserService(CandidateRegisterRequestDTO request)
        {
            var dto = _mapper.Map<CandidateUserServiceDTO>(request);
            var producer = new RegisterProducer("RegisterCandidate");
            producer.RegisterCandidate(dto);
            await Task.CompletedTask;
        }

        internal async Task SendRecruiterDataToUserService(RecruiterRegisterRequestDTO request)
        {
            var dto = _mapper.Map<RecruiterUserServiceDTO>(request);
            var producer = new RegisterProducer("RegisterRecruiter");
            producer.RegisterRecruiter(dto);
            await Task.CompletedTask;
        }

        internal async Task SendCredentialsToLoginService(BaseDTO request)
        {
            var dto = _mapper.Map<CredentailsDTO>(request);
            var producer = new RegisterProducer("RegisterCredentials");
            producer.RegisterCredentials(dto);
            await Task.CompletedTask;
        }
    }
}
