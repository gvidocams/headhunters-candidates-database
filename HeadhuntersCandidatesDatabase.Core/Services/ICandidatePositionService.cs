using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface ICandidatePositionService : IEntityService<CandidatePositions>
    {
        bool Exists(int id, int positionId);
        CandidatePositions ApplyCandidateToPosition(int id, int positionId);
    }
}