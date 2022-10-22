using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class CompanyService : EntityService<Company>, ICompanyService
    {
        private IEntityService<Company> _entityService;
        public CompanyService(
            IHeadHuntersCandidatesDbContext context,
            IEntityService<Company> entityService)
            : base(context)
        {
            _entityService = entityService;
        }

        public bool Exists(Company company)
        {
            return _context.Companies.Any(c => c.CompanyName.ToLower() == company.CompanyName.ToLower() &&
                                               c.Description.ToLower() == company.Description.ToLower());
        }

        public bool Exists(int id)
        {
            return _context.Companies.Any(c => c.Id == id);
        }

        public void Update(int id, Company company)
        {
            var c = _entityService.GetById(id);

            if (company.CompanyName != null)
            {
                c.CompanyName = company.CompanyName;
            }

            _entityService.Update(c);
        }

        public void Delete(int id)
        {
            var company = _entityService.GetById(id);

            var companyPositions = _context.CompanyPositions
                .Where(cp => cp.Company.Id == id);

            var positions = _context.Positions
                .Where(p => companyPositions.Any(cp => cp.Position.Id == p.Id));

            var positionSkills = _context.PositionSkills
                .Where(ps => positions.Any(p => p.Id == ps.Id));

            var appliedCandidates = _context.CandidatesPositions
                .Where(c => companyPositions.Any(cp => cp.Position.Id == c.Position.Id));

            _context.PositionSkills.RemoveRange(positionSkills);
            _context.CandidatesPositions.RemoveRange(appliedCandidates);
            _context.CompanyPositions.RemoveRange(companyPositions);
            _context.Positions.RemoveRange(positions);
            _context.SaveChanges();

            _entityService.Delete(company);
        }
    }
}