using System.Collections.Generic;

namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public class Candidate : Entity
    {
        public string FullName { get; set; }
        public List<Position> PositionsAppliedTo { get; set; }
    }
}
