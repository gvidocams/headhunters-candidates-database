using System;
using System.Threading.Tasks;
using HeadhuntersCandidatesDatabase.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HeadhuntersCandidatesDatabase.Data
{
    public class HeadhuntersCandidatesDbContext : DbContext
    {
        public HeadhuntersCandidatesDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Company> Companies { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
