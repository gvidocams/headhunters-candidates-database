using System;
using HeadhuntersCandidatesDatabase.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HeadhuntersCandidatesDatabase.Services
{
    /*
    public class HeadhuntersService
    {
        private CandidatesService _candidateService;
        private CompanyService _companyService;

        public HeadhuntersService(CandidatesService candidateService, CompanyService companyService)
        {
            _candidateService = candidateService;
            _companyService = companyService;
        }

        public Company[] GetCompaniesForCandidate(int candidateId)
        {
            var potentialCompanies = new List<Company>();
            var companies = _companyService.GetCompanies().ToList();

            var candidateSkillset = _candidateService.GetCandidateById(candidateId).SkillSet;
            


            foreach (var company in companies)
            {
                if(IsAdequateForCandidate(company, candidateSkillset))
            }
        }

        public Candidate[] GetCandidatesForJobPosition(JobPosition jobPosition)
        {
            var potentialCandidates = new List<Candidate>();
            var candidates = _candidateService.GetCandidates().ToList();

            foreach (var candidate in candidates)
            {
                if (IsAdequateForJobPosition(jobPosition.SkillRequirements, candidate))
                {
                    potentialCandidates.Add(candidate);
                }
            }

            return potentialCandidates.ToArray();
        }

        public bool IsAdequateForJobPosition(string[] requiredSkills, string[] skillset)
        {
            foreach (var requiredSkill in requiredSkills)
            {
                if (!candidate.SkillSet.Contains(requiredSkill))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsAdequateForCandidate(Company companies, )
        {
            


        }
    }
    */
}
