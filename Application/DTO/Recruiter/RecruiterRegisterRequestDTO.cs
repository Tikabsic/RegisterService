using Application.Enums;

namespace Application.DTO.Recruiter
{
    public class RecruiterRegisterRequestDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public Region CompanyRegion { get; set; }
        public string CompanyAddress { get; set; }
    }
}
