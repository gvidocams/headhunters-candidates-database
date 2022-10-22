using System.Collections.Generic;
using System.Linq;
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
    public class CompanyApiController : BaseHrController
    {
        private readonly ICompanyService _companyService;
        private readonly ICompanyPositionService _companyPositionService;
        private readonly IEnumerable<ICompanyValidator> _companyValidators;
        private readonly IEnumerable<IPositionValidator> _positionValidators;

        public CompanyApiController(
            ICompanyService companyService,
            ICompanyPositionService companyPositionService,
            IEnumerable<ICompanyValidator> companyValidators,
            IEnumerable<IPositionValidator> positionValidators,
            IMapper mapper) : base(mapper)
        {
            _companyService = companyService;
            _companyPositionService = companyPositionService;
            _companyValidators = companyValidators;
            _positionValidators = positionValidators;
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

            var response = _mapper.Map<CompanyResponse>(company);

            return Ok(response);
        }
        
        [HttpPost]
        public IActionResult PutCompany(CompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);

            if (!_companyValidators.Any(c => c.IsValid(company))) 
            {
                return BadRequest();
            }

            if (_companyService.Exists(company))
            {
                return Conflict();
            }

            _companyService.Create(company);

            var response = _mapper.Map<CompanyResponse>(company);

            return Created("", response);
        }

        [Route("{id}/position")]
        [HttpPost]
        public IActionResult AddPositionToCompany(int id, PositionRequest request)
        {
            var position = _mapper.Map<Position>(request);


            if (!_positionValidators.All(p => p.IsValid(position)))
            {
                return BadRequest();
            }

            if (_companyPositionService.Exists(id, position))
            {
                return Conflict();
            }
            
            var companyPosition = _companyPositionService.AddPositionToCompany(id, position);

            return Created("", companyPosition);
        }

        [Route("{id}")]
        [HttpPatch]
        public IActionResult UpdateCompany(int id, CompanyRequest request)
        {
            var company = _mapper.Map<Company>(request);

            if (!_companyValidators.Any(c => c.IsValid(company)))
            {
                return BadRequest();
            }

            if (_companyService.Exists(company))
            {
                return Conflict();
            }

            _companyService.Update(id, company);

            var response = _mapper.Map<CompanyResponse>(company);

            return Ok(response);
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
