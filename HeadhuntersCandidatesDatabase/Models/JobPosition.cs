namespace HeadhuntersCandidatesDatabase.Models
{
    public class JobPosition
    {
        public Company Company { get; set; }
        public string PositionName { get; set; }
        public int PositionCount { get; set; }
        public string SkillRequirements { get; set; }
    }
}
