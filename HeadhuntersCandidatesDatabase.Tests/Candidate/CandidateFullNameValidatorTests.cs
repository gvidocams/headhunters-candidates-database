using FluentAssertions;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Core.Validations;
using Xunit;

namespace HeadhuntersCandidatesDatabase.Tests.Candidate
{
    public class CandidateFullNameValidatorTests
    {
        private CandidateFullNameValidator _validator = new CandidateFullNameValidator();

        [Fact]
        public void FullName_PassesNullValue_ReturnsFalse()
        {
            var candidate = new Core.Models.Candidate()
            {
                FullName = null,
                Age = 20,
                AboutMe = "I am a passionate developer :)"
            };

            _validator.IsValid(candidate).Should().BeFalse();
        }

        [Fact]
        public void FullName_PassesEmptyValue_ReturnsFalse()
        {
            var candidate = new Core.Models.Candidate()
            {
                FullName = "",
                Age = 20,
                AboutMe = "I am a passionate developer :)"
            };

            _validator.IsValid(candidate).Should().BeFalse();
        }

        [Fact]
        public void FullName_PassesValidValue_ReturnsTrue()
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