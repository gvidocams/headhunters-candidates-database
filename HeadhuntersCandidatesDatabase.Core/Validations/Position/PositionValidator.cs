using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class PositionValidator : IPositionValidator
    {
        public bool IsValid(Position position)
        {
            return !(string.IsNullOrEmpty(position.Title) ||
                   position.OpenedPositions < 1);
        }
    }
}