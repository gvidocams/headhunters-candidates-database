using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class CandidateFullNameValidator : ICandidateValidator
    {
        public bool IsValid(Candidate candidate)
        {
            return !string.IsNullOrEmpty(candidate.FullName);
        }
    }
}