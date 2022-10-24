using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class CandidateAgeValidator : ICandidateValidator
    {
        public bool IsValid(Candidate candidate)
        {
            return candidate.Age > 0;
        }
    }
}