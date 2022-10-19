using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api")]
    [ApiController]
    public class CandidateApiController : ControllerBase
    {
        private ICandidateService _candidateService;
        private ICandidatePositionService _candidatePositionService;

        public CandidateApiController(
            ICandidateService candidateService,
            ICandidatePositionService candidatePositionService)
        {
            _candidateService = candidateService;
            _candidatePositionService = candidatePositionService;
        }

        [Route("candidate/{id}")]
        [HttpGet]
        public IActionResult GetCandidate(int id)
        {
            var candidate = _candidateService.GetById(id);

            return Ok(candidate);
        }

        [Route("candidate")]
        [HttpPut]
        public IActionResult PutCandidate(Candidate candidate)
        {
            _candidateService.Create(candidate);

            return Created("", candidate);
        }

        [Route("candidate/{candidateId}/position/{positionId}")]
        [HttpPut]
        public IActionResult ApplyCandidateToPosition(int candidateId, int positionId)
        {
            var candidatePosition = _candidatePositionService.ApplyCandidateToPosition(candidateId, positionId);

            return Created("", candidatePosition);
        }

        [Route("candidate/{id}")]
        [HttpPut]
        public IActionResult AddSkillToCandidate(int id, Skill skill)
        {
            var candidateSkill = _candidateService.ApplySkill(id, skill);
            
            return Ok(candidateSkill);
        }

        [Route("candidate/{candidateId}/skill/{skillId}")]
        [HttpDelete]
        public IActionResult RemoveSkillFromCandidate(int candidateId, int skillId)
        {
            _candidateService.RemoveSkill(candidateId, skillId);

            return Ok();
        }

        [Route("candidate/{id}")]
        [HttpPatch]
        public IActionResult UpdateCandidate(Candidate candidate, int id)
        {
            // validation
            if (_candidateService.GetById(id) == null)
            {
                return BadRequest();
            }

            var c = _candidateService.Update(id, candidate);

            return Ok(c);
        }

        [Route("candidate/{id}")]
        [HttpDelete]
        public IActionResult DeleteCandidate(int id)
        {
            _candidateService.Delete(id);
            return Ok();
        }
    }
}
