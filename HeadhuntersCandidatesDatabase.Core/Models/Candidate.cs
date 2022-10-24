namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public class Candidate : Entity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string AboutMe { get; set; }
    }
}
