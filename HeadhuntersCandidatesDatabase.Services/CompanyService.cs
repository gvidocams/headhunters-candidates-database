﻿using HeadhuntersCandidatesDatabase.Core.Models;
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
                .Include(cp => cp.Position)
                .Include(cp => cp.Company)
                .Where(cp => cp.Company.Id == id);

            var positions = _context.Positions
                .Where(p => companyPositions.Any(cp => cp.Position.Id == p.Id));

            var appliedCandidates = _context.CandidatesPositions
                .Include(c => c.Position)
                .Include(c => c.Candidate)
                .Where(c => companyPositions.Any(cp => cp.Position.Id == c.Position.Id));

            _context.CandidatesPositions.RemoveRange(appliedCandidates);
            _context.CompanyPositions.RemoveRange(companyPositions);
            _context.Positions.RemoveRange(positions);
            _context.SaveChanges();

            _entityService.Delete(company);
        }
    }
}