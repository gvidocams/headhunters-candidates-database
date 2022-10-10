using HeadhuntersCandidatesDatabase.Exceptions;
using HeadhuntersCandidatesDatabase.Models;
using System.Collections.Generic;
using System.Linq;

namespace HeadhuntersCandidatesDatabase.Services
{
    public class CandidatesService
    {
        private List<Candidate> _candidates;
        private int _id = 1;

        public CandidatesService(List<Candidate> candidates)
        {
            _candidates = candidates;
        }

        public Candidate[] GetCandidates()
        {
            return _candidates.ToArray();
        }

        public Candidate GetCandidateById(int id)
        {
            var candidate = _candidates.FirstOrDefault(c => c.Id == id);

            return candidate;
        }

        public void AddCandidate(Candidate candidate)
        {
            Validate.Candidate(candidate);

            Validate.DuplicateCandidate(_candidates, candidate);
            
            candidate.Id = _id++;
            _candidates.Add(candidate);
        }

        public void UpdateCandidate(int id, Candidate updatedCandidate)
        {
            Validate.Candidate(updatedCandidate);

            
            var c = _candidates.FirstOrDefault(c => c.Id == id);

            if (c == null)
            {
                throw new InvalidIdException(id);
            }

            c.FullName = updatedCandidate.FullName;
            c.SkillSet = updatedCandidate.SkillSet;
        }

        public void RemoveCandidate(int id)
        {
            var candidate = _candidates.FirstOrDefault(c => c.Id == id);

            if (candidate != null)
            {
                _candidates.Remove(candidate);
            }
        }

        public void ClearCandidates()
        {
            _candidates.Clear();

            _id = 1;
        }
    }
}
