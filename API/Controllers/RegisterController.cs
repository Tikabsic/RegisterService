using Application.DTO.Candidate;
using Application.DTO.Recruiter;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _service;
        public RegisterController(IRegisterService service)
        {
            _service = service;
        }


        [HttpPost("registercandidate")]
        public async Task<ActionResult> RegisterCandidate(CandidateRegisterRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            await _service.RegisterCandidate(request);
            return Ok();
        }

        [HttpPost("registerrecruiter")]
        public async Task<ActionResult> RegisterRecruiter(RecruiterRegisterRequestDTO request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            await _service.RegisterRecruiter(request);
            return Ok();
        }
    }
}
