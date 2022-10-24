using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class CompanyCompanyNameValidator : ICompanyValidator
    {
        public bool IsValid(Company company)
        {
            return !string.IsNullOrWhiteSpace(company.CompanyName);
        }
    }
}