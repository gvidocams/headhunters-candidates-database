using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class CompanyDescriptionValidator : ICompanyValidator
    {
        public bool IsValid(Company company)
        {
            return !string.IsNullOrEmpty(company.Description);
        }
    }
}