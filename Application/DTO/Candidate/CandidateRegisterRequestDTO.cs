using Application.Enums;

namespace Application.DTO.Candidate
{

    public class CandidateRegisterRequestDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Region Region { get; set; }
        public string City { get; set; }
    }
}
