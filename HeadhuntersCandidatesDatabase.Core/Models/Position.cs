﻿using System.Collections.Generic;

namespace HeadhuntersCandidatesDatabase.Core.Models
{
    public class Position : Entity
    {
        public string Title { get; set; }
        public int OpenedPositions { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}
