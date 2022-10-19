﻿using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class CompanyPositionService : EntityService<CompanyPositions>, ICompanyPositionService
    {
        public CompanyPositionService(IHeadHuntersCandidatesDbContext context) : base(context)
        {
        }

        public CompanyPositions AddPositionToCompany(int companyId, Position position)
        {
            var company = _context.Companies.SingleOrDefault(c => c.Id == companyId);

            _context.Positions.Add(position);

            var companyPosition = new CompanyPositions() { Company = company, Position = position };

            _context.CompanyPositions.Add(companyPosition);
            _context.SaveChanges();

            return companyPosition;
        }
    }
}