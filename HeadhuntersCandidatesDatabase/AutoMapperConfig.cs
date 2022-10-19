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
                    cfg.CreateMap<CandidateRequest, Candidate>()
                        .ForMember(d => d.Id, opt => opt.Ignore());
                    cfg.CreateMap<Candidate, CandidateRequest>();

                    cfg.CreateMap<CompanyRequest, Company>()
                        .ForMember(d => d.Id, opt => opt.Ignore());
                    cfg.CreateMap<Company, CompanyRequest>();

                    cfg.CreateMap<SkillRequest, Skill>()
                        .ForMember(d => d.Id, opt => opt.Ignore());
                    cfg.CreateMap<Skill, SkillRequest>();

                    cfg.CreateMap<PositionRequest, Position>()
                        .ForMember(d => d.Id, opt => opt.Ignore());
                    cfg.CreateMap<Position, PositionRequest>();
                });

            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }
    }
}