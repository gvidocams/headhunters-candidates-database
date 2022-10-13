using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private EntityService<Company> _entityService;

        public CompanyApiController(EntityService<Company> entityService)
        {
            _entityService = entityService;
        }

        [Route("company/{id}")]
        [HttpGet]
        public IActionResult GetCompany(int id)
        {
            var company = _entityService.GetById(id);
            return Ok(company);
        }

        [Route("company")]
        [HttpPut]
        public IActionResult PutCompany(Company company)
        {
            _entityService.Create(company);

            return Created("", company);
        }
    }
}
