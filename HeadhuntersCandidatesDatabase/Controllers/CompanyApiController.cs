using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Core.Validations;
using HeadhuntersCandidatesDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyApiController : ControllerBase
    {
        private ICompanyService _companyService;
        private ICompanyPositionService _companyPositionService;
        private ICompanyValidator _companyValidator;
        private IPositionValidator _positionValidator;
        private IMapper _mapper;

        public CompanyApiController(
            ICompanyService companyService,
            ICompanyPositionService companyPositionService,
            ICompanyValidator companyValidator,
            IPositionValidator positionValidator,
            IMapper mapper)
        {
            _companyService = companyService;
            _companyPositionService = companyPositionService;
            _companyValidator = companyValidator;
            _positionValidator = positionValidator;
            _mapper = mapper;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCompany(int id)
        {
            var company = _companyService.GetById(id);

            if (company == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<CompanyRequest>(company);

            return Ok(response);
        }
        
        [HttpPut]
        public IActionResult PutCompany(CompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);

            if (!_companyValidator.IsValid(company))
            {
                return BadRequest();
            }

            if (_companyService.Exists(company))
            {
                return Conflict();
            }

            _companyService.Create(company);

            request = _mapper.Map<CompanyRequest>(company);

            return Created("", request);
        }

        [Route("{id}/position")]
        [HttpPut]
        public IActionResult AddPositionToCompany(int id, PositionRequest request)
        {
            var position = _mapper.Map<Position>(request);

            if (!_positionValidator.IsValid(position))
            {
                return BadRequest();
            }

            if (_companyPositionService.Exists(id, position))
            {
                return Conflict();
            }

            //todo vai šim taisīt mapperi?
            var companyPosition = _companyPositionService.AddPositionToCompany(id, position);

            return Created("", companyPosition);
        }

        [Route("{id}")]
        [HttpPatch]
        public IActionResult UpdateCompany(int id, CompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);

            if (!_companyValidator.IsValid(company))
            {
                return BadRequest();
            }

            if (_companyService.Exists(company))
            {
                return Conflict();
            }

            _companyService.Update(id, company);

            request = _mapper.Map<CompanyRequest>(company);

            return Ok(request);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteCompany(int id)
        {
            if (!_companyService.Exists(id))
            {
                return NotFound();
            }

            _companyService.Delete(id);

            return Ok();
        }
    }
}
