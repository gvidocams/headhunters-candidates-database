using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Core.Validations;
using HeadhuntersCandidatesDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    public class CandidateApiController : BaseHrController
    {
        private ICandidateService _candidateService;
        private ICandidatePositionService _candidatePositionService;
        private IEnumerable<ICandidateValidator> _candidateValidators;
        private IPositionService _positionService;
        private ISkillService _skillService;
        private ISkillValidator _skillValidator;

        public CandidateApiController(
            ICandidateService candidateService,
            ICandidatePositionService candidatePositionService,
            IEnumerable<ICandidateValidator> candidateValidators,
            IPositionService positionService,
            ISkillService skillService,
            ISkillValidator skillValidator,
            IMapper mapper) : base(mapper)
        {
            _candidateService = candidateService;
            _candidatePositionService = candidatePositionService;
            _candidateValidators = candidateValidators;
            _positionService = positionService;
            _skillService = skillService;
            _skillValidator = skillValidator;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCandidate(int id)
        {
            var candidate = _candidateService.GetById(id);

            if (candidate == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<CandidateResponse>(candidate);

            return Ok(response);
        }
        
        [HttpPost]
        public IActionResult PutCandidate(CandidateRequest request)
        {
            var candidate = _mapper.Map<Candidate>(request);

            if (!_candidateValidators.Any(c => c.IsValid(candidate)))
            {
                return BadRequest();
            }

            if (_candidateService.Exists(candidate))
            {
                return Conflict();
            }

            _candidateService.Create(candidate);

            var response = _mapper.Map<CandidateResponse>(candidate);

            return Created("", response);
        }

        [Route("{id}/position/{positionId}")]
        [HttpPost]
        public IActionResult ApplyCandidateToPosition(int id, int positionId)
        {
            if (!_candidateService.Exists(id) ||
                !_positionService.Exists(positionId))
            {
                return NotFound();
            }

            if (_candidatePositionService.Exists(id, positionId))
            {
                return Conflict();
            }

            var candidatePosition = _candidatePositionService.ApplyCandidateToPosition(id, positionId);

            return Created("", candidatePosition);
        }

        [Route("{id}/position/{positionId}")]
        [HttpDelete]
        public IActionResult RemoveCandidateFromPosition(int id, int positionId)
        {
            if (!_candidatePositionService.Exists(id, positionId))
            {
                return NotFound();
            }

            _candidatePositionService.RemoveCandidateFromPosition(id, positionId);

            return Ok();
        }

        [Route("{id}")]
        [HttpPost]
        public IActionResult AddSkillToCandidate(int id, SkillRequest request)
        {
            var skill = _mapper.Map<Skill>(request);

            if (!_skillValidator.IsValid(skill))
            {
                return BadRequest();
            }

            if (!_candidateService.Exists(id))
            {
                return NotFound();
            }
            
            CandidateSkills candidateSkill;

            try
            {
                candidateSkill = _candidateService.ApplySkill(id, skill);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
            
            return Created("", candidateSkill);
        }

        [Route("{id}/skill/{skillId}")]
        [HttpDelete]
        public IActionResult RemoveSkillFromCandidate(int id, int skillId)
        {
            if (!_candidateService.Exists(id) ||
                !_skillService.Exists(skillId))
            {
                return NotFound();
            }

            _candidateService.RemoveSkill(id, skillId);

            return Ok();
        }

        [Route("{id}")]
        [HttpPatch]
        public IActionResult UpdateCandidate(CandidateRequest request, int id)
        {
            var candidate = _mapper.Map<Candidate>(request);

            if (_candidateValidators.Any(c => !c.IsValid(candidate)))
            {
                return BadRequest();
            }

            if (!_candidateService.Exists(id))
            {
                return NotFound();
            }

            if (_candidateService.Exists(candidate))
            {
                return Conflict();
            }

            var c = _candidateService.Update(id, candidate);

            var response = _mapper.Map<CandidateResponse>(c);

            return Ok(response);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteCandidate(int id)
        {
            if (!_candidateService.Exists(id))
            {
                return NotFound();
            }

            _candidateService.Delete(id);

            return Ok();
        }
    }
}
