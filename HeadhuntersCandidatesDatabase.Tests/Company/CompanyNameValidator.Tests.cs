using FluentAssertions;
using HeadhuntersCandidatesDatabase.Core.Validations;
using Xunit;

namespace HeadhuntersCandidatesDatabase.Tests.Company
{
    public class CompanyNameValidatorTests
    {
        private CompanyCompanyNameValidator _validator = new CompanyCompanyNameValidator();

        [Fact]
        public void CompanyName_PassesNullValue_ReturnsFalse()
        {
            var company = new Core.Models.Company()
            {
                CompanyName = null,
                Description = "IT company"
            };

            _validator.IsValid(company).Should().BeFalse();
        }

        [Fact]
        public void CompanyName_PassesEmptyValue_ReturnsFalse()
        {
            var company = new Core.Models.Company()
            {
                CompanyName = "",
                Description = "IT company"
            };

            _validator.IsValid(company).Should().BeFalse();
        }

        [Fact]
        public void CompanyName_PassesValidValue_ReturnsTrue()
        {
            var company = new Core.Models.Company()
            {
                CompanyName = "CatchSmart",
                Description = "IT company"
            };

            _validator.IsValid(company).Should().BeTrue();
        }
    }
}