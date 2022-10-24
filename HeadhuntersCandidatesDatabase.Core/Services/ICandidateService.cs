using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface ICandidateService : IEntityService<Candidate>
    {
        bool Exists(int id);
        bool Exists(Candidate candidate);
        CandidateSkills ApplySkill(int id, Skill skill);
        void RemoveSkill(int candidateId, int skillId);
        Candidate Update(int id, Candidate candidate);
        void Delete(int id);

    }
}