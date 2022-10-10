using HeadhuntersCandidatesDatabase.Models;
using HeadhuntersCandidatesDatabase.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        
        public AdminApiController() { }
        /*
        public AdminApiController(List<Candidate> candidates, List<Company> companies)
        {
            _candidates = candidates;
            _companies = companies;
        }
        */
        [HttpGet]
        [Route("candidates")]
        public IActionResult GetCandidates()
        {
            return Ok();
        }
        /*
        [HttpGet]
        [Route("candidates/{id}")]
        public IActionResult GetCandidate(int id)
        {
            //var candidate = HeadhuntersService.GetCandidateById(id);

            return Ok(candidate);
        }

        [HttpPut]
        [Route("candidates")]
        public IActionResult PutCandidate(Candidate candidate)
        {
            // todo validation
            _candidates.Add(candidate);

            return Created("", candidate);
        }

        [HttpPatch]
        [Route("candidates")]
        public IActionResult UpdateCandidate(Candidate candidate)
        {
            // todo validation
            var c = _candidates.FirstOrDefault(c => c.Id == candidate.Id);

            c = candidate;

            return Ok();
        }

        [HttpDelete]
        [Route("candidates/{id}")]
        public IActionResult DeleteCandidate(int id)
        {
            var candidate = _candidates.FirstOrDefault(c => c.Id == id);

            if(candidate != null)
            {
                _candidates.Remove(candidate);
            }

            return Ok();
        }

        // Company api

        [HttpGet]
        [Route("companies")]
        public IActionResult GetCompanies()
        {
            return Ok(_companies.ToArray());
        }

        [HttpGet]
        [Route("companies/{id}")]
        public IActionResult GetCompany(int id)
        {
            var company = _companies.FirstOrDefault(c => c.Id == id);

            return Ok(company);
        }

        [HttpPut]
        [Route("companies")]
        public IActionResult PutCompany(Company company)
        {
            // todo validation
            _companies.Add(company);

            return Created("", company);
        }

        [HttpDelete]
        [Route("companies/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var company = _companies.FirstOrDefault(c => c.Id == id);

            if(company != null)
            {
                _companies.Remove(company);
            }

            return Ok();
        }
        */
    }
}
