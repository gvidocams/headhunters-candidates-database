using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface ICompanyService : IEntityService<Company>
    {
        bool Exists(Company company);
        bool Exists(int id);
        void Update(int id, Company company);
        void Delete(int id);
    }
}