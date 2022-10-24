using FluentAssertions;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Validations;
using Xunit;

namespace HeadhuntersCandidatesDatabase.Tests.Candidate
{
    public class CandidateAboutMeValidatorTests
    {
        private CandidateAboutMeValidator _validator = new CandidateAboutMeValidator();

        [Fact]
        public void AboutMe_PassesNullValue_ReturnsFalse()
        {
            var candidate = new Core.Models.Candidate()
            {
                FullName = "Gvido Andis Cams",
                Age = 20,
                AboutMe = null
            };

            _validator.IsValid(candidate).Should().BeFalse();
        }

        [Fact]
        public void AboutMe_PassesEmptyValue_ReturnsFalse()
        {
            var candidate = new Core.Models.Candidate()
            {
                FullName = "Gvido Andis Cams",
                Age = 20,
                AboutMe = ""
            };

            _validator.IsValid(candidate).Should().BeFalse();
        }

        [Fact]
        public void AboutMe_PassesValidValue_ReturnsTrue()
        {
            var candidate = new Core.Models.Candidate()
            {
                FullName = "Gvido Andis Cams",
                Age = 20,
                AboutMe = "I am a passionate developer :)"
            };

            _validator.IsValid(candidate).Should().BeTrue();
        }
    }
}
