using HeadhuntersCandidatesDatabase.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace HeadhuntersCandidatesDatabase.Data
{
    public interface IHeadHuntersCandidatesDbContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entry) where T : class;
        DbSet<Candidate> Candidates { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Skill> Skills { get; set; }
        DbSet<CandidatePositions> CandidatesPositions { get; set; }
        DbSet<CompanyPositions> CompanyPositions { get; set; }
        DbSet<CandidateSkills> CandidatesSkills { get; set; }
        DbSet<PositionSkills> PositionSkills { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
