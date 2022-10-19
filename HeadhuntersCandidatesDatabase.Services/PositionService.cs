using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Exceptions;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using Microsoft.EntityFrameworkCore;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class PositionService : EntityService<Position>, IPositionService
    {
        private readonly IEntityService<Position> _entityService;
        public PositionService(
            IHeadHuntersCandidatesDbContext context, 
            IEntityService<Position> entityService)
            : base(context)
        {
            _entityService = entityService;
        }

        public bool Exists(int id)
        {
            return _context.Positions.Any(p => p.Id == id);
        }

        public PositionSkills ApplySkill(int id, Skill skill)
        {
            var position = _entityService.GetById(id);

            if (_context.PositionSkills.Any(ps => ps.Position.Id == position.Id &&
                                                  ps.Skill.Name.ToLower() == skill.Name.ToLower()))
            {
                throw new DuplicateSkillException();
            }

            var existingSkill = _context.Skills
                .SingleOrDefault(s => s.Name.ToLower() == skill.Name.ToLower());

            var positionSkill = new PositionSkills() { Position = position, Skill = existingSkill };

            if (existingSkill == null)
            {
                _context.Skills.Add(skill);
                _context.SaveChanges();

                positionSkill.Skill = skill;
            }

            _context.PositionSkills.Add(positionSkill);
            _context.SaveChanges();

            return positionSkill;
        }

        public void RemoveSkill(int positionId, int skillId)
        {
            var positionSkill = _context.PositionSkills
                .Include(ps => ps.Position)
                .Include(ps => ps.Skill)
                .SingleOrDefault(ps => ps.Position.Id == positionId && ps.Skill.Id == skillId);

            if (positionSkill != null)
            {
                _context.PositionSkills.Remove(positionSkill);
                _context.SaveChanges();
            }
        }

        public Position Update(int id, Position position)
        {
            var p = _entityService.GetById(id);

            if (position.Title != null)
            {
                p.Title = position.Title;
            }

            _entityService.Update(p);

            return p;
        }

        public void Delete(int id)
        {
            var position = _entityService.GetById(id);

            if (position == null) { return; }

            var companiesPosition = _context.CompanyPositions
                .Include(cp => cp.Position)
                .Include(cp => cp.Company)
                .Where(cp => cp.Position.Id == position.Id);

            var appliedCandidates = _context.CandidatesPositions
                .Include(cp => cp.Position)
                .Include(cp => cp.Candidate)
                .Where(cp => cp.Position.Id == position.Id);

            _context.CompanyPositions.RemoveRange(companiesPosition);
            _context.CandidatesPositions.RemoveRange(appliedCandidates);
            _context.SaveChanges();

            _entityService.Delete(position);
        }
    }
}