using FluentAssertions;
using HeadhuntersCandidatesDatabase.Core.Validations;
using Xunit;

namespace HeadhuntersCandidatesDatabase.Tests.Position
{
    public class PositionTitleValidatorTests
    {
        private PositionTitleValidator _validator = new PositionTitleValidator();

        [Fact]
        public void Title_PassesNullValue_ReturnsFalse()
        {
            var position = new Core.Models.Position
            {
                Title = null,
                OpenedPositions = 12
            };

            _validator.IsValid(position).Should().BeFalse();
        }

        [Fact]
        public void Title_PassesEmptyValue_ReturnsFalse()
        {
            var position = new Core.Models.Position
            {
                Title = "",
                OpenedPositions = 12
            };

            _validator.IsValid(position).Should().BeFalse();
        }

        [Fact]
        public void Title_PassesValidValue_ReturnsTrue()
        {
            var position = new Core.Models.Position
            {
                Title = ".NET Developer",
                OpenedPositions = 12
            };

            _validator.IsValid(position).Should().BeTrue();
        }
    }
}