using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface ISkillService : IEntityService<Skill>
    {
        void Delete(int id);
    }
}