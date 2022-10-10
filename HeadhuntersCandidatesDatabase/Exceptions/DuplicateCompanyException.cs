using System;

namespace HeadhuntersCandidatesDatabase.Exceptions
{
    public class DuplicateCompanyException : Exception
    {
        public DuplicateCompanyException(string companyName)
            : base($"Company with name {companyName} already exists!") { }
    }
}