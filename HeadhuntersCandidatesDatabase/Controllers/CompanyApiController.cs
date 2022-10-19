using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private ICompanyService _companyService;
        private ICompanyPositionService _companyPositionService;

        public CompanyApiController(
            ICompanyService companyService,
            ICompanyPositionService companyPositionService)
        {
            _companyService = companyService;
            _companyPositionService = companyPositionService;
        }

        [Route("company/{id}")]
        [HttpGet]
        public IActionResult GetCompany(int id)
        {
            var company = _companyService.GetById(id);

            return Ok(company);
        }

        [Route("company")]
        [HttpPut]
        public IActionResult PutCompany(Company company)
        {
            _companyService.Create(company);

            return Created("", company);
        }

        [Route("company/{id}")]
        [HttpPut]
        public IActionResult AddPositionToCompany(int id, Position position)
        {
            if (position.OpenedPositions < 1)
            {
                return BadRequest();
            }

            var companyPosition = _companyPositionService.AddPositionToCompany(id, position);

            return Created("", companyPosition);
        }

        [Route("company/{id}")]
        [HttpPatch]
        public IActionResult UpdateCompany(int id, Company company)
        {
            _companyService.Update(id, company);

            return Ok(company);
        }

        [Route("company/{id}")]
        [HttpDelete]
        public IActionResult DeleteCompany(int id)
        {
            _companyService.Delete(id);

            return Ok();
        }
    }
}
