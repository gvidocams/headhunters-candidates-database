using FluentAssertions;
using HeadhuntersCandidatesDatabase.Core.Validations;
using HeadhuntersCandidatesDatabase.Core.Models;
using Xunit;

namespace HeadhuntersCandidatesDatabase.Tests.Position
{
    public class PositionOpenedPositionsTests
    {
        private PositionOpenedPositionsValidator _validator = new PositionOpenedPositionsValidator();

        [Fact]
        public void OpenedPositions_PassesValueLessThanOne_ReturnsFalse()
        {
            var position = new Core.Models.Position
            {
                Title = ".NET Developer",
                OpenedPositions = 0
            };

            _validator.IsValid(position).Should().BeFalse();
        }

        [Fact]
        public void OpenedPositions_PassesValueOne_ReturnsTrue()
        {
            var position = new Core.Models.Position
            {
                Title = ".NET Developer",
                OpenedPositions = 1
            };

            _validator.IsValid(position).Should().BeTrue();
        }
    }
}