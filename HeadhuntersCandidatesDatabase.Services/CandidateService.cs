using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class CandidateService : EntityService<Candidate>, ICandidateService
    {
        private IEntityService<Candidate> _entityService;
        public CandidateService(
            IHeadHuntersCandidatesDbContext context,
            IEntityService<Candidate> entityService
            ) : base(context)
        {
            _entityService = entityService;
        }

        public CandidateSkills ApplySkill(int id, Skill skill)
        {
            var candidate = _entityService.GetById(id);

            if (candidate == null) { return null; }

            var existingSkill = _context.Skills
                .SingleOrDefault(s => s.Name.ToLower() == skill.Name.ToLower());

            var candidateSkill = new CandidateSkills() { Candidate = candidate, Skill = existingSkill };

            if (existingSkill == null)
            {
                _context.Skills.Add(skill);
                _context.SaveChanges();

                candidateSkill.Skill = skill;
            }

            _context.CandidatesSkills.Add(candidateSkill);
            _context.SaveChanges();

            return candidateSkill;
        }

        public void RemoveSkill(int candidateId, int skillId)
        {
            var candidateSkill = _context.CandidatesSkills
                .Include(ps => ps.Candidate)
                .Include(ps => ps.Skill)
                .SingleOrDefault(ps => ps.Candidate.Id == candidateId && ps.Skill.Id == skillId);

            if (candidateSkill != null)
            {
                _context.CandidatesSkills.Remove(candidateSkill);
                _context.SaveChanges();
            }
        }

        public Candidate Update(int id, Candidate candidate)
        {
            var c = _entityService.GetById(id);

            if(c == null) { return candidate; }

            if (candidate.FullName != null)
            {
                c.FullName = candidate.FullName;
            }

            _entityService.Update(c);

            return c;
        }

        public void Delete(int id)
        {
            var candidate = _entityService.GetById(id);

            if(candidate == null) { return; }

            var appliedPositions = _context.CandidatesPositions
                .Include(cp => cp.Candidate)
                .Include(cp => cp.Position)
                .Where(cp => cp.Candidate.Id == candidate.Id);

            _context.CandidatesPositions.RemoveRange(appliedPositions);
            _context.SaveChanges();

            _entityService.Delete(candidate);
        }
    }
}