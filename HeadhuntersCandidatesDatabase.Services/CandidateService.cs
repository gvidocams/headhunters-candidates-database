using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Exceptions;

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

        public bool Exists(int id)
        {
            return _context.Candidates.Any(c => c.Id == id);
        }

        public bool Exists(Candidate candidate)
        {
            return _context.Candidates.Any(c => c.FullName.ToLower() == candidate.FullName.ToLower() &&
                                                c.Age == candidate.Age &&
                                                c.AboutMe.ToLower() == candidate.AboutMe.ToLower());
        }

        public CandidateSkills ApplySkill(int id, Skill skill)
        {
            var candidate = _entityService.GetById(id);

            if (_context.CandidatesSkills.Any(cs => cs.Candidate.Id == candidate.Id &&
                                                    cs.Skill.Name.ToLower() == skill.Name.ToLower()))
            {
                throw new DuplicateSkillException();
            }

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
                .SingleOrDefault(ps => ps.Candidate.Id == candidateId && ps.Skill.Id == skillId);
            
            _context.CandidatesSkills.Remove(candidateSkill);
            _context.SaveChanges();
        }

        public Candidate Update(int id, Candidate candidate)
        {
            var c = _entityService.GetById(id);

            c.FullName = candidate.FullName;
            c.Age = candidate.Age;
            c.AboutMe = candidate.AboutMe;

            _entityService.Update(c);

            return c;
        }

        public void Delete(int id)
        {
            var candidate = _entityService.GetById(id);

            var appliedPositions = _context.CandidatesPositions
                .Where(cp => cp.Candidate.Id == candidate.Id);

            _context.CandidatesPositions.RemoveRange(appliedPositions);
            _context.SaveChanges();

            _entityService.Delete(candidate);
        }
    }
}