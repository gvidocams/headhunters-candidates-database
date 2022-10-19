using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface ICandidatePositionService : IEntityService<CandidatePositions>
    {
        CandidatePositions ApplyCandidateToPosition(int candidateId, int positionId);
    }
}