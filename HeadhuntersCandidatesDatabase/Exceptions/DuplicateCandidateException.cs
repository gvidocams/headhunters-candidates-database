using System;

namespace HeadhuntersCandidatesDatabase.Exceptions
{
    public class DuplicateCandidateException : Exception
    {
        public DuplicateCandidateException(string fullName)
            : base($"Candidate with name {fullName} already exists!") { }
    }
}