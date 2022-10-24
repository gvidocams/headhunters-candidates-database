using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class PositionOpenedPositionsValidator : IPositionValidator
    {
        public bool IsValid(Position company)
        {
            return company.OpenedPositions > 0;
        }
    }
}