using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public interface ICompanyValidator
    {
        bool IsValid(Company company);
    }
}