namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public class CompanyPositions : Entity
    {
        public Company Company { get; set; }
        public Position Position { get; set; }
    }
}
