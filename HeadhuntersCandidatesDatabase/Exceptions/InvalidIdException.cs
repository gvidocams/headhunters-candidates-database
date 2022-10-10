using System;

namespace HeadhuntersCandidatesDatabase.Exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException(int id) 
            : base($"An entity with id {id} doesn't exist!") {}
    }
}
