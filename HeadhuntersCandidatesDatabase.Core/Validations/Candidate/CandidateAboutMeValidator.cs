using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class CandidateAboutMeValidator : ICandidateValidator
    {
        public bool IsValid(Candidate candidate)
        {
            return !string.IsNullOrEmpty(candidate.AboutMe);
        }
    }
}