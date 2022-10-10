using FluentAssertions;
using HeadhuntersCandidatesDatabase.Exceptions;
using HeadhuntersCandidatesDatabase.Models;
using HeadhuntersCandidatesDatabase.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace HeadHuntersCandidatesDatabase.Tests
{
    public class CompanyServiceTests
    {
        private List<Company> _companies;
        private CompanyService _companyService;
        private List<Company> _validCompanies;
        private Company _invalidCompany;

        public CompanyServiceTests()
        {
            _companies = new List<Company>();
            _companyService = new CompanyService(_companies);
            _validCompanies = Storage.CreateValidCompanies();
            _invalidCompany = new Company { CompanyName = null, OpenedPositions = null };
        }

        [Fact]
        public void GetCompanies_ShouldReturnCompanyArray()
        {
            _companyService.GetCompanies().Should().BeEquivalentTo(_companies.ToArray());
        }

        [Fact]
        public void GetCompanyById_ShouldReturnACompany()
        {
            _companies.Add(_validCompanies[0]);

            _companyService.GetCompanyById(1).Should().BeEquivalentTo(_validCompanies[0]);
        }

        [Fact]
        public void GetCompanyById_ShouldReturnACompanyFromMultipleCompanies()
        {
            _companyService.AddCompany(_validCompanies[0]);
            _companyService.AddCompany(_validCompanies[1]);
            _companyService.AddCompany(_validCompanies[2]);

            _companyService.GetCompanyById(1).Should().BeEquivalentTo(_validCompanies[0]);
            _companyService.GetCompanyById(2).Should().BeEquivalentTo(_validCompanies[1]);
            _companyService.GetCompanyById(3).Should().BeEquivalentTo(_validCompanies[2]);
        }

        [Fact]
        public void AddCompany_AddsAValidCompany_CompanyShouldExistInCompaniesList()
        {
            _companyService.AddCompany(_validCompanies[0]);

            _companies[0].Should().BeEquivalentTo(_validCompanies[0]);
        }

        [Fact]
        public void AddCompany_AddsADuplicateCompany_ThrowsDuplicateCompanyException()
        {
            _companies.Add(_validCompanies[0]);

            Action act = () =>
                _companyService.AddCompany(_validCompanies[0]);

            act.Should().Throw<DuplicateCompanyException>()
                .WithMessage("Company with name CatchSmart already exists!");
        }

        [Fact]
        public void AddCompany_AddsAnInvalidCompanyWithNullValues_ThrowsNullValueInRequestException()
        {
            Action act = () =>
                _companyService.AddCompany(_invalidCompany);

            act.Should().Throw<NullValueInRequestException>()
                .WithMessage("Can't be null values in this request!");
        }

        [Fact]
        public void UpdateCompany_ShouldUpdateAnExistingCompany()
        {
            _companies.Add(_validCompanies[0]);

            _validCompanies[0].CompanyName = "Test";

            _companyService.UpdateCompany(1, _validCompanies[0]);

            _companies[0].Should().BeEquivalentTo(_validCompanies[0]);
        }

        [Fact]
        public void UpdateCompany_PassInvalidCompany_ThrowsNullValueInRequestException()
        {
            var invalidCompany = new Company
            {
                CompanyName = null,
                OpenedPositions = null
            };

            _companies.Add(_validCompanies[0]);

            Action act = () =>
                _companyService.UpdateCompany(1, invalidCompany);

            act.Should().Throw<NullValueInRequestException>()
                .WithMessage("Can't be null values in this request!");
        }

        [Fact]
        public void UpdateCandidate_PassInvalidId_ThrowsInvalidIdException()
        {
            _companies.Add(_validCompanies[0]);

            Action act = () =>
                _companyService.UpdateCompany(5, _validCompanies[0]);

            act.Should().Throw<InvalidIdException>()
                .WithMessage("An entity with id 5 doesn't exist!");
        }

        [Fact]
        public void RemoveCompany_RemovesValidCompany()
        {
            _companies.Add(_validCompanies[0]);

            _companyService.RemoveCompany(1);

            _companies.Should().BeEmpty();
        }

        [Fact]
        public void ClearCandidates_ShouldClearCandidatesList()
        {
            _companies.Add(_validCompanies[0]);
            _companies.Add(_validCompanies[1]);
            _companies.Add(_validCompanies[2]);

            _companyService.ClearCompanies();

            _companies.Should().BeEmpty();
        }
    }
}