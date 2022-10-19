using System;
using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Core.Validations;
using HeadhuntersCandidatesDatabase.Models;
using HeadhuntersCandidatesDatabase.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/candidate")]
    [ApiController]
    public class CandidateApiController : ControllerBase
    {
        private ICandidateService _candidateService;
        private ICandidatePositionService _candidatePositionService;
        private ICandidateValidator _candidateValidator;
        private IPositionService _positionService;
        private ISkillService _skillService;
        private ISkillValidator _skillValidator;
        private IMapper _mapper;

        public CandidateApiController(
            ICandidateService candidateService,
            ICandidatePositionService candidatePositionService,
            ICandidateValidator candidateValidator,
            IPositionService positionService,
            ISkillService skillService,
            ISkillValidator skillValidator,
            IMapper mapper)
        {
            _candidateService = candidateService;
            _candidatePositionService = candidatePositionService;
            _candidateValidator = candidateValidator;
            _positionService = positionService;
            _skillService = skillService;
            _skillValidator = skillValidator;
            _mapper = mapper;
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

            var response = _mapper.Map<CandidateRequest>(candidate);

            return Ok(response);
        }
        
        [HttpPut]
        public IActionResult PutCandidate(CandidateRequest request)
        {
            var candidate = _mapper.Map<Candidate>(request);

            if (!_candidateValidator.IsValid(candidate))
            {
                return BadRequest();
            }

            if (_candidateService.Exists(candidate))
            {
                return Conflict();
            }

            _candidateService.Create(candidate);

            request = _mapper.Map<CandidateRequest>(candidate);

            return Created("", request);
        }

        [Route("{id}/position/{positionId}")]
        [HttpPut]
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
            //todo vai šim taisīt mapperi?
            var candidatePosition = _candidatePositionService.ApplyCandidateToPosition(id, positionId);

            return Created("", candidatePosition);
        }

        [Route("{id}")]
        [HttpPut]
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

            //todo vai šim taisīt mapperi?
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

            if (!_candidateValidator.IsValid(candidate))
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

            request = _mapper.Map<CandidateRequest>(c);

            return Ok(request);
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
