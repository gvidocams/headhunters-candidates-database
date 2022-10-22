using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Core.Validations;
using HeadhuntersCandidatesDatabase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api/skill")]
    [ApiController]
    public class SkillApiController : BaseHrController
    {
        private ISkillService _skillService;
        private ISkillValidator _skillValidator;

        public SkillApiController(
            ISkillService skillService,
            ISkillValidator skillValidator,
            IMapper mapper) : base(mapper)
        {
            _skillService = skillService;
            _skillValidator = skillValidator;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetSkill(int id)
        {
            var skill = _skillService.GetById(id);

            if (skill == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SkillResponse>(skill);

            return Ok(response);
        }
        
        [HttpPost]
        public IActionResult PutSkill(SkillRequest request)
        {
            var skill = _mapper.Map<Skill>(request);

            if (!_skillValidator.IsValid(skill))
            {
                return BadRequest();
            }

            if (_skillService.Exists(skill))
            {
                return Conflict();
            }

            _skillService.Create(skill);

            var response = _mapper.Map<SkillResponse>(skill);

            return Created("", response);
        }

        [Route("{id}")]
        [HttpPatch]
        public IActionResult UpdateSkill(int id, SkillRequest request)
        {
            var skill = _mapper.Map<Skill>(request);

            if (!_skillValidator.IsValid(skill))
            {
                return BadRequest();
            }

            if (_skillService.Exists(skill))
            {
                return Conflict();
            }

            _skillService.Update(id, skill);

            var response = _mapper.Map<SkillResponse>(skill);

            return Ok(response);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteSkill(int id)
        {
            if (!_skillService.Exists(id))
            {
                return NotFound();
            }

            _skillService.Delete(id);

            return Ok();
        }
    }
}
