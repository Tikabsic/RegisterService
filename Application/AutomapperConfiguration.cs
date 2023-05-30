using Application.DTO;
using Application.DTO.Candidate;
using Application.DTO.Recruiter;
using AutoMapper;
using System.Drawing;

namespace Application
{
    internal class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            CreateMap<BaseDTO, CredentailsDTO>();

            //Mapowanie z requesta kandydata na poszczególne DTO
            CreateMap<CandidateRegisterRequestDTO, CandidateUserServiceDTO>();

            //Mapowanie z requesta rekrutera na poszczególne DTO
            CreateMap<RecruiterRegisterRequestDTO, RecruiterUserServiceDTO>();
        }
    }
}
