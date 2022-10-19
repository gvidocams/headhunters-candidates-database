using System;

namespace HeadhuntersCandidatesDatabase.Core.Exceptions
{
    public class DuplicateSkillException : Exception
    {
        public DuplicateSkillException() 
            : base("Candidate already has this skill!") { }
    }
}