using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public interface ICandidateValidator
    {
        bool IsValid(Candidate candidate);
    }
}