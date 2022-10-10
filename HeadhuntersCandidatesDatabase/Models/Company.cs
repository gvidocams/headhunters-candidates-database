using System.Collections.Generic;

namespace HeadhuntersCandidatesDatabase.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public List<JobPosition> OpenedPositions { get; set; }
    }
}
