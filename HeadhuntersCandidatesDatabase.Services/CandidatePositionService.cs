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

        public bool Exists(int id, int positionId)
        {
            return _context.CandidatesPositions.Any(cp => cp.Candidate.Id == id &&
                                                          cp.Position.Id == positionId);
        }

        public CandidatePositions ApplyCandidateToPosition(int id, int positionId)
        {
            var candidate = _context.Candidates.SingleOrDefault(c => c.Id == id);
            var position = _context.Positions.SingleOrDefault(p => p.Id == positionId);

            var candidatePosition = new CandidatePositions() { Candidate = candidate, Position = position };

            _context.CandidatesPositions.Add(candidatePosition);
            _context.SaveChanges();

            return candidatePosition;
        }

        public void RemoveCandidateFromPosition(int id, int positionId)
        {
            var candidate = _context.Candidates.SingleOrDefault(c => c.Id == id);
            var position = _context.Positions.SingleOrDefault(p => p.Id == positionId);

            var candidatePosition = _context.CandidatesPositions.SingleOrDefault(cp => cp.Candidate.Id == id &&
                                                     cp.Position.Id == positionId);

            _context.CandidatesPositions.Remove(candidatePosition);
            _context.SaveChanges();
        }
    }
}