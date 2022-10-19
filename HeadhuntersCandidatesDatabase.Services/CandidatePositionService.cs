using System.Linq;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Services;
using HeadhuntersCandidatesDatabase.Data;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class CandidatePositionService : EntityService<CandidatePositions>, ICandidatePositionService
    {

        public CandidatePositionService(IHeadHuntersCandidatesDbContext context) : base(context)
        {
        }

        public CandidatePositions ApplyCandidateToPosition(int candidateId, int positionId)
        {
            var candidate = _context.Candidates.SingleOrDefault(c => c.Id == candidateId);
            var position = _context.Positions.SingleOrDefault(p => p.Id == positionId);

            var candidatePosition = new CandidatePositions() { Candidate = candidate, Position = position };

            _context.CandidatesPositions.Add(candidatePosition);
            _context.SaveChanges();

            return candidatePosition;
        }
    }
}