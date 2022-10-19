using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Validations
{
    public class SkillValidator : ISkillValidator
    {
        public bool IsValid(Skill skill)
        {
            return !string.IsNullOrEmpty(skill.Name);
        }
    }
}