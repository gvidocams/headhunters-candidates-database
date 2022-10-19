using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class SkillService : EntityService<Skill>, ISkillService
    {
        public SkillService(IHeadHuntersCandidatesDbContext context) : base(context)
        {
        }

        public void Delete(int id)
        {
            var skill = _context.Skills.SingleOrDefault(s => s.Id == id);

            if(skill == null) { return; }

            var candidatesWithSkill = _context.CandidatesSkills
                .Include(cs => cs.Candidate)
                .Include(cs => cs.Skill)
                .Where(cs => cs.Skill.Id == skill.Id);

            var positionsWithSkill = _context.PositionSkills
                .Include(ps => ps.Position)
                .Include(ps => ps.Skill)
                .Where(ps => ps.Skill.Id == skill.Id);

            _context.CandidatesSkills.RemoveRange(candidatesWithSkill);
            _context.PositionSkills.RemoveRange(positionsWithSkill);
            _context.Skills.Remove(skill);
            _context.SaveChanges();
        }
    }
}