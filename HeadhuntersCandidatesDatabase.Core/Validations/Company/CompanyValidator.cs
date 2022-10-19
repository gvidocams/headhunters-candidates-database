using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class CompanyValidator : ICompanyValidator
    {
        public bool IsValid(Company company)
        {
            return (!string.IsNullOrEmpty(company.CompanyName) ||
                   !string.IsNullOrEmpty(company.Description));
        }
    }
}