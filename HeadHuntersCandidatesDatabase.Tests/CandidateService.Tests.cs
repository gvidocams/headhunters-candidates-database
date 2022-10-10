using FluentAssertions;
using HeadhuntersCandidatesDatabase.Exceptions;
using HeadhuntersCandidatesDatabase.Models;
using HeadhuntersCandidatesDatabase.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace HeadHuntersCandidatesDatabase.Tests
{
    public class CandidateServiceTests
    {
        private List<Candidate> _validCandidates = Storage.CreateValidCandidates();

        private List<Candidate> _candidates;
        private CandidatesService _candidateService;

        public CandidateServiceTests()
        {
            _candidates = new List<Candidate>();
            _candidateService = new CandidatesService(_candidates);
        }

        [Fact]
        public void GetCandidates_ShouldReturnCandidateArray()
        {
            _candidateService.GetCandidates().Should().BeEquivalentTo(_candidates.ToArray());
        }

        [Fact]
        public void GetCandidateById_ShouldReturnACandidate()
        {
            _candidates.Add(_validCandidates[0]);
            
            _candidateService.GetCandidateById(1).Should().BeEquivalentTo(_validCandidates[0]);
        }

        [Fact]
        public void GetCandidateById_ShouldReturnACandidateFromMultipleCandidates()
        {
            _candidateService.AddCandidate(_validCandidates[0]);
            _candidateService.AddCandidate(_validCandidates[1]);
            _candidateService.AddCandidate(_validCandidates[2]);
            
            _candidateService.GetCandidateById(1).Should().BeEquivalentTo(_validCandidates[0]);
            _candidateService.GetCandidateById(2).Should().BeEquivalentTo(_validCandidates[1]);
            _candidateService.GetCandidateById(3).Should().BeEquivalentTo(_validCandidates[2]); 
        }

        [Fact]
        public void AddCandidate_AddsAValidCandidate_CandidateShouldExistInCandidatesList()
        {
            _candidateService.AddCandidate(_validCandidates[0]);

            _candidates[0].Should().BeEquivalentTo(_validCandidates[0]);
        }

        [Fact]
        public void AddCandidate_AddsADuplicateCandidate_ThrowsDuplicateCandidateException()
        {
            _candidates.Add(_validCandidates[0]);

            Action act = () => 
                _candidateService.AddCandidate(_validCandidates[0]);

            act.Should().Throw<DuplicateCandidateException>()
                .WithMessage("Candidate with name John Doe already exists!");
        }

        public static IEnumerable<Object[]> InvalidCandidateData()
        {
            yield return new object[] { new Candidate { FullName = null, SkillSet = new[] { "C#", ".NET", "HTTP & Basic WEB API" } } };
            yield return new object[] { new Candidate { FullName = "John Smith", SkillSet = null } };
            yield return new object[] { new Candidate { FullName = null, SkillSet = null } };
        }

        [Theory]
        [MemberData(nameof(InvalidCandidateData))]
        public void AddCandidate_AddsAnInvalidCandidateWithNullValues_ThrowsNullValueInRequestException(Candidate invalidCandidate)
        {
            Action act = () =>
                _candidateService.AddCandidate(invalidCandidate);

            act.Should().Throw<NullValueInRequestException>()
                .WithMessage("Can't be null values in this request!");
        }

        [Fact]
        public void UpdateCandidate_ShouldUpdateAnExistingCandidate()
        {
            _candidates.Add(_validCandidates[0]);

            _validCandidates[0].FullName = "Test";

            _candidateService.UpdateCandidate(1, _validCandidates[0]);

            _candidates[0].Should().BeEquivalentTo(_validCandidates[0]);
        }

        [Theory]
        [MemberData(nameof(InvalidCandidateData))]
        public void UpdateCandidate_PassInvalidCandidate_ThrowsNullValueInRequestException(Candidate invalidCandidate)
        {
            _candidates.Add(_validCandidates[0]);

            Action act = () => 
                _candidateService.UpdateCandidate(1, invalidCandidate);

            act.Should().Throw<NullValueInRequestException>()
                .WithMessage("Can't be null values in this request!");
        }

        [Fact]
        public void UpdateCandidate_PassInvalidId_ThrowsInvalidIdException()
        {
            _candidates.Add(_validCandidates[0]);

            Action act = () =>
                _candidateService.UpdateCandidate(5, _validCandidates[1]);

            act.Should().Throw<InvalidIdException>()
                .WithMessage("An entity with id 5 doesn't exist!");
        }

        [Fact]
        public void RemoveCandidate_RemovesValidCandidate()
        {
            _candidates.Add(_validCandidates[0]);

            _candidateService.RemoveCandidate(1);

            _candidates.Should().BeEmpty();
        }

        [Fact]
        public void ClearCandidates_ShouldClearCandidatesList()
        {
            _candidates.Add(_validCandidates[0]);
            _candidates.Add(_validCandidates[1]);
            _candidates.Add(_validCandidates[2]);

            _candidateService.ClearCandidates();

            _candidates.Should().BeEmpty();
        }
    }
}
