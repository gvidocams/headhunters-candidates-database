using System;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Validations;
using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/position")]
    [ApiController]
    public class PositionApiController : ControllerBase
    {
        private IPositionService _positionService;
        private IPositionValidator _positionValidator;
        private ISkillService _skillService;
        private ISkillValidator _skillValidator;
        private IMapper _mapper;

        public PositionApiController(
            IPositionService positionService,
            IPositionValidator positionValidator,
            ISkillService skillService,
            ISkillValidator skillValidator,
            IMapper mapper)
        {
            _positionService = positionService;
            _positionValidator = positionValidator;
            _skillService = skillService;
            _skillValidator = skillValidator;
            _mapper = mapper;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetPosition(int id)
        {
            var position = _positionService.GetById(id);

            if (position == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<PositionRequest>(position);

            return Ok(response);
        }

        [Route("{id}/skill")]
        [HttpPut]
        public IActionResult AddSkillToPosition(int id, Skill skill)
        {
            if (!_skillValidator.IsValid(skill))
            {
                return BadRequest();
            }

            if (!_positionService.Exists(id))
            {
                return NotFound();
            }

            PositionSkills positionSkill;

            try
            {
                positionSkill = _positionService.ApplySkill(id, skill);
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }

            return Created("", positionSkill);
        }

        [Route("{id}/skill/{skillId}")]
        [HttpDelete]
        public IActionResult RemoveSkillFromPosition(int id, int skillId)
        {
            if (!_positionService.Exists(id) ||
                !_skillService.Exists(skillId))
            {
                return NotFound();
            }

            _positionService.RemoveSkill(id, skillId);

            return Ok();
        }
        
        [Route("{id}")]
        [HttpPatch]
        public IActionResult UpdatePosition(int id, PositionRequest request)
        {
            var position = _mapper.Map<Position>(request);

            if (!_positionValidator.IsValid(position))
            {
                return BadRequest();
            }

            var p = _positionService.Update(id, position);

            return Ok(p);
        }

        
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePosition(int id)
        {
            if (!_positionService.Exists(id))
            {
                return NotFound();
            }

            _positionService.Delete(id);

            return Ok();
        }
    }
}
