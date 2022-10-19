using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class CandidateValidator : ICandidateValidator
    {
        public bool IsValid(Candidate candidate)
        {
            if (candidate == null ||
                candidate.FullName == null ||
                candidate.AboutMe == null)
            {
                return false;
            }

            return true;
        }
    }
}