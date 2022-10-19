using System.Text.Json.Serialization;

namespace HeadhuntersCandidatesDatabase.Models
{
    public class CandidateRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string AboutMe { get; set; }
    }
}