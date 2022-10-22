using AutoMapper;
using HeadhuntersCandidatesDatabase.Core.Models;
using HeadhuntersCandidatesDatabase.Models;

namespace HeadhuntersCandidatesDatabase
{
    public class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<CandidateRequest, Candidate>();
                    cfg.CreateMap<Candidate, CandidateResponse>();

                    cfg.CreateMap<CompanyRequest, Company>();
                    cfg.CreateMap<Company, CompanyResponse>();

                    cfg.CreateMap<SkillRequest, Skill>();
                    cfg.CreateMap<Skill, SkillResponse>();

                    cfg.CreateMap<PositionRequest, Position>();
                    cfg.CreateMap<Position, PositionResponse>();
                });

            return config.CreateMapper();
        }
    }
}