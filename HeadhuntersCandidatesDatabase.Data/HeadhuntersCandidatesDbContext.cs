using HeadhuntersCandidatesDatabase.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HeadhuntersCandidatesDatabase.Data
{
    public class HeadhuntersCandidatesDbContext : DbContext, IHeadHuntersCandidatesDbContext
    {
        public HeadhuntersCandidatesDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CompanyPositions> CompanyPositions { get; set; }
        public DbSet<CandidatePositions> CandidatesPositions { get; set; }
        public DbSet<CandidateSkills> CandidatesSkills { get; set; }
        public DbSet<PositionSkills> PositionSkills { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
