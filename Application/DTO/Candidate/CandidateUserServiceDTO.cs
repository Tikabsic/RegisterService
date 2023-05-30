using Application.Enums;

namespace Application.DTO.Candidate
{
    internal class CandidateUserServiceDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Region Region { get; set; }
        public string City { get; set; }
    }
}
