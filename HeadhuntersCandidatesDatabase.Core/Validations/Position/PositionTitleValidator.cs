using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class PositionTitleValidator : IPositionValidator
    {
        public bool IsValid(Position company)
        {
            return !string.IsNullOrEmpty(company.Title);
        }
    }
}