using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private HeadhuntersCandidatesDbContext _context;

        public CompanyApiController(HeadhuntersCandidatesDbContext context)
        {
            _context = context;
        }

        [Route("company/{id}")]
        [HttpGet]
        public IActionResult GetCompany(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);
            return Ok(company);
        }

        [Route("company")]
        [HttpPut]
        public IActionResult PutCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();

            return Created("", company);
        }
    }
}
