using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public interface ISkillValidator
    {
        bool IsValid(Skill skill);
    }
}