using HeadhuntersCandidatesDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("test/{id}")]
        public IActionResult GetCandidate(int id)
        {
            var candidate = new Candidate() { Id = 0, FullName = "Gvido Andis Čams" };
            return Ok(candidate);
        }
    }
}
