using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class SkillNameValidator : ISkillValidator
    {
        public bool IsValid(Skill skill)
        {
            return !string.IsNullOrEmpty(skill.Name);
        }
    }
}