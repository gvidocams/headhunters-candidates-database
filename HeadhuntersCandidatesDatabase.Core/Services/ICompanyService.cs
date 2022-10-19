using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface ICompanyService : IEntityService<Company>
    {
        void Update(int id, Company company);
        void Delete(int id);
    }
}