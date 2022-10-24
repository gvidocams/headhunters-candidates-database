namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public class CandidateSkills : Entity
    {
        public Candidate Candidate { get; set; }
        public Skill Skill { get; set; }
    }
}