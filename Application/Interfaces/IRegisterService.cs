using Application.DTO;
using Application.DTO.Candidate;
using Application.DTO.Recruiter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRegisterService
    {
        Task RegisterCandidate(CandidateRegisterRequestDTO request);
        Task RegisterRecruiter(RecruiterRegisterRequestDTO request);
    }
}
