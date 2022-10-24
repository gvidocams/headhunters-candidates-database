using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface ISkillService : IEntityService<Skill>
    {
        bool Exists(Skill skill);
        bool Exists(int id);
        Skill Update(int id, Skill skill);
        void Delete(int id);
    }
}