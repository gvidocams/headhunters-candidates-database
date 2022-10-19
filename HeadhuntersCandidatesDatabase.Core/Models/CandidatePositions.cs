namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public class CandidatePositions : Entity
    {
        public Candidate Candidate { get; set; }
        public Position Position { get; set; }
    }
}