using FluentAssertions;
using HeadhuntersCandidatesDatabase.Core.Validations;
using HeadhuntersCandidatesDatabase.Core.Models;
using Xunit;

namespace HeadhuntersCandidatesDatabase.Tests.Candidate
{
    public class CandidateAgeValidatorTests
    {
        private CandidateAgeValidator _validator = new CandidateAgeValidator();

        [Fact]
        public void Age_PassesValueLessThanOne_ReturnsFalse()
        {
            var candidate = new Core.Models.Candidate()
            {
                FullName = "Gvido Andis Cams",
                Age = 0,
                AboutMe = "I am a passionate developer :)"
            };

            _validator.IsValid(candidate).Should().BeFalse();
        }

        [Fact]
        public void Age_PassesValueMoreThanOne_ReturnsFalse()
        {
            var candidate = new Core.Models.Candidate()
            {
                FullName = "Gvido Andis Cams",
                Age = 1,
                AboutMe = "I am a passionate developer :)"
            };

            _validator.IsValid(candidate).Should().BeTrue();
        }
    }
}