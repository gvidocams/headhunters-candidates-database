using FluentAssertions;
using HeadhuntersCandidatesDatabase.Exceptions;
using HeadhuntersCandidatesDatabase.Models;
using HeadhuntersCandidatesDatabase.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace HeadHuntersCandidatesDatabase.Tests
{
    public class HeadhuntersServiceTests
    {
        private List<Candidate> _candidates;
        private List<Company> _companies;

        private CandidatesService _candidatesService;
        private CompanyService _companyService;

        private HeadhuntersService _headhuntersService;

        public HeadhuntersServiceTests()
        {
            _candidates = Storage.CreateValidCandidates();
            _companies = Storage.CreateValidCompanies();

            _candidatesService = new CandidatesService(_candidates);
            _companyService = new CompanyService(_companies);

            _headhuntersService = new HeadhuntersService(_candidatesService, _companyService);
        }

        [Fact]
        public void GetCandidatesForJobPosition_ShouldReturnTwoCandidates()
        {
            var candidates = _headhuntersService.GetCandidatesForJobPosition(_companies[0].OpenedPositions[0]);

            candidates.Should().BeEquivalentTo(new[] { _candidates[0], _candidates[3] });
        }


    }
}