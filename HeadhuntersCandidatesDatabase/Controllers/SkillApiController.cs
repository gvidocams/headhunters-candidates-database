using HeadhuntersCandidatesDatabase.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeadhuntersCandidatesDatabase.Controllers
{
    [Route("api")]
    [ApiController]
    public class SkillApiController : ControllerBase
    {
        private ISkillService _skillService;

        public SkillApiController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [Route("skill/{id}")]
        [HttpDelete]
        public IActionResult DeleteSkill(int id)
        {
            _skillService.Delete(id);

            return Ok();
        }
    }
}
