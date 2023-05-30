using Application.Enums;

namespace Application.DTO.Recruiter
{
    internal class RecruiterUserServiceDTO
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public Region CompanyRegion { get; set; }
        public string CompanyAddress { get; set; }
    }
}
