using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public interface IPositionValidator
    {
        bool IsValid(Position company);
    }
}