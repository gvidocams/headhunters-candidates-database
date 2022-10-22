using FluentAssertions;
using HeadhuntersCandidatesDatabase.Core.Validations;
using Xunit;

namespace HeadhuntersCandidatesDatabase.Tests.Skill
{
    public class SkillNameValidatorTests
    {
        private SkillNameValidator _validator = new SkillNameValidator();

        [Fact]
        public void Name_PassesNullValue_ReturnsFalse()
        {
            var skill = new Core.Models.Skill
            {
                Name = null
            };

            _validator.IsValid(skill).Should().BeFalse();
        }

        [Fact]
        public void Name_PassesEmptyValue_ReturnsFalse()
        {
            var skill = new Core.Models.Skill
            {
                Name = ""
            };

            _validator.IsValid(skill).Should().BeFalse();
        }

        [Fact]
        public void Name_PassesValidValue_ReturnsTrue()
        {
            var skill = new Core.Models.Skill
            {
                Name = ".NET"
            };

            _validator.IsValid(skill).Should().BeTrue();
        }
    }
}