using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api")]
    [ApiController]
    public class PositionApiController : ControllerBase
    {
        private IPositionService _positionService;

        public PositionApiController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [Route("position/{id}")]
        [HttpGet]
        public IActionResult GetPosition(int id)
        {
            var position = _positionService.GetById(id);

            return Ok(position);
        }

        [Route("position/{id}")]
        [HttpPut]
        public IActionResult AddSkillToPosition(int id, Skill skill)
        {
            var positionSkill = _positionService.ApplySkill(id, skill);

            return Ok(positionSkill);
        }

        [Route("position/{positionId}/skill/{skillId}")]
        [HttpDelete]
        public IActionResult RemoveSkillFromPosition(int positionId, int skillId)
        {
            _positionService.RemoveSkill(positionId, skillId);

            return Ok();
        }
        
        [Route("position/{id}")]
        [HttpPatch]
        public IActionResult UpdatePosition(int id, Position position)
        {
            var p = _positionService.Update(id, position);

            return Ok(p);
        }

        
        [Route("position")]
        [HttpDelete]
        public IActionResult DeletePosition(int id)
        {
            _positionService.Delete(id);

            return Ok();
        }
    }
}
