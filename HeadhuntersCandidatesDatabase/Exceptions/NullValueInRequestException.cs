using System;

namespace HeadhuntersCandidatesDatabase.Exceptions
{
    public class NullValueInRequestException : Exception
    {
        public NullValueInRequestException()
            : base("Can't be null values in this request!") { }
    }
}
