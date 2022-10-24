using FluentAssertions;
using HeadhuntersCandidatesDatabase.Core.Validations;
using Xunit;
using Models = HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Tests.Company
{
    public class CompanyDescriptionValidatorTests
    {
        private CompanyDescriptionValidator _validator = new CompanyDescriptionValidator();

        [Fact]
        public void Description_PassesNullValue_ReturnsFalse()
        {
            var company = new Models.Company
            {
                CompanyName = "CatchSmart",
                Description = null
            };

            _validator.IsValid(company).Should().BeFalse();
        }

        [Fact]
        public void Description_PassesEmptyValue_ReturnsFalse()
        {
            var company = new Models.Company
            {
                CompanyName = "CatchSmart",
                Description = ""
            };

            _validator.IsValid(company).Should().BeFalse();
        }

        [Fact]
        public void Description_PassesValidValue_ReturnsTrue()
        {
            var company = new Models.Company
            {
                CompanyName = "CatchSmart",
                Description = "IT company"
            };

            _validator.IsValid(company).Should().BeTrue();
        }
    }
}