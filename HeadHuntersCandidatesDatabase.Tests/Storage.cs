using System;
using HeadhuntersCandidatesDatabase.Models;
using System.Collections.Generic;

namespace HeadHuntersCandidatesDatabase.Tests
{
    public static class Storage
    {
        public static List<Company> CreateValidCompanies()
        {
            return new List<Company>()
            {
                new Company
                {
                    Id = 1,
                    CompanyName = "CatchSmart",
                    OpenedPositions = new[]
                    {
                        new JobPosition
                        {
                            PositionName = "NET. C# Developer",
                            PositionCount = 1,
                            SkillRequirements = new[]
                            {
                                "C#",
                                ".NET",
                                "SQL",
                                "API"
                            }
                        }
                    }
                },
                new Company
                {
                    Id = 2,
                    CompanyName = "AKO",
                    OpenedPositions = new[]
                    {
                        new JobPosition
                        {
                            PositionName = "FrontEnd developer",
                            PositionCount = 5,
                            SkillRequirements = new[]
                            {
                                "HTML",
                                "CSS",
                                "JS",
                                "Angular"
                            }
                        },
                        new JobPosition
                        {
                            PositionName = "NET. C# Developer",
                            PositionCount = 3,
                            SkillRequirements = new[]
                            {
                                "C#",
                                ".NET",
                                "SQL",
                                "API"
                            }
                        }
                    }
                },
                new Company
                {
                    Id = 3,
                    CompanyName = "Gvido IT Solutions",
                    OpenedPositions = new[]
                    {
                        new JobPosition
                        {
                            PositionName = "Software Tester",
                            PositionCount = 25,
                            SkillRequirements = new[]
                            {
                                "C#",
                                ".NET",
                                "SQL",
                                "API"
                            }
                        }
                    }
                },

                new Company
                {
                    Id = 4,
                    CompanyName = "Aleksis Services",
                    OpenedPositions = new[]
                    {
                        new JobPosition
                        {
                            PositionName = "Python Developer",
                            PositionCount = 1,
                            SkillRequirements = new []
                            {
                                "Python"
                            }
                        }
                    }
                },
            };
        }

        public static List<Candidate> CreateValidCandidates()
        {
            return new List<Candidate>()
            {
                new Candidate { Id = 1, FullName = "John Doe", SkillSet = new[] { "C#", ".NET", "SQL", "API" } },
                new Candidate { Id = 2, FullName = "Alex Williams", SkillSet = new[] { "Python", "Ruby", "Advanced data structures" } },
                new Candidate { Id = 3, FullName = "Tim Cook", SkillSet = new[] { "Java", "HTTP & Basic WEB API" } },
                new Candidate { Id = 4, FullName = "Aleksis Anisimovs", SkillSet = new [] { "C#", ".NET", "SQL", "API" }}
            };
        }
    }
}
