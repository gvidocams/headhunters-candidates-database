using HeadhuntersCandidatesDatabase.Data;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("admin-api")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly HeadhuntersCandidatesDbContext _context;

        public AdminApiController(HeadhuntersCandidatesDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            _context.Candidates.RemoveRange(_context.Candidates);
            _context.Companies.RemoveRange(_context.Companies);
            _context.Positions.RemoveRange(_context.Positions);
            _context.CandidatesPositions.RemoveRange(_context.CandidatesPositions);
            _context.CompanyPositions.RemoveRange(_context.CompanyPositions);
            _context.SaveChanges();

            return Ok();
        }
    }
}
