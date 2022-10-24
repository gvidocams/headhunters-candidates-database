using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using System.Linq;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class SkillService : EntityService<Skill>, ISkillService
    {
        public SkillService(IHeadHuntersCandidatesDbContext context) : base(context)
        {
        }

        public bool Exists(Skill skill)
        {
            return _context.Skills.Any(s => s.Name.ToLower() == skill.Name.ToLower());
        }

        public bool Exists(int id)
        {
            return _context.Skills.Any(s => s.Id == id);
        }

        public Skill Update(int id, Skill skill)
        {
            var s = _context.Skills.SingleOrDefault(s => s.Id == id);

            if (skill.Name != null)
            {
                s.Name = skill.Name;
            }

            return s;
        }

        public void Delete(int id)
        {
            var skill = _context.Skills.SingleOrDefault(s => s.Id == id);

            var candidatesWithSkill = _context.CandidatesSkills
                .Where(cs => cs.Skill.Id == skill.Id);

            var positionsWithSkill = _context.PositionSkills
                .Where(ps => ps.Skill.Id == skill.Id);

            _context.CandidatesSkills.RemoveRange(candidatesWithSkill);
            _context.PositionSkills.RemoveRange(positionsWithSkill);
            _context.Skills.Remove(skill);
            _context.SaveChanges();
        }
    }
}