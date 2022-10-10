using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using HeadhuntersCandidatesDatabase.Exceptions;
using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase
{
    public static class Validate
    {
        public static void Candidate(Candidate candidate)
        {
            if (candidate.FullName == null ||
                candidate.SkillSet == null)
            {
                throw new NullValueInRequestException();
            }
        }

        public static void Company(Company company)
        {
            if (company.CompanyName == null ||
                company.OpenedPositions == null)
            {
                throw new NullValueInRequestException();
            }
        }

        public static void DuplicateCandidate(List<Candidate> candidates, Candidate candidate)
        {
            var duplicateCandidate = candidates.FirstOrDefault(c => c.FullName == candidate.FullName);

            if (duplicateCandidate != null)
            {
                throw new DuplicateCandidateException(candidate.FullName);
            }
        }

        public static void DuplicateCompany(List<Company> companies, Company company)
        {
            var duplicateCompany = companies.FirstOrDefault(c => c.CompanyName == company.CompanyName);

            if (duplicateCompany != null)
            {
                throw new DuplicateCompanyException(company.CompanyName);
            }
        }
    }
}
