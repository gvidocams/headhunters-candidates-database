using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface IPositionService : IEntityService<Position>
    {
        bool Exists(int id);
        PositionSkills ApplySkill(int id, Skill skill);
        void RemoveSkill(int positionId, int skillId);
        Position Update(int id, Position position);
        void Delete(int id);
    }
}