using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface ICompanyPositionService : IEntityService<CompanyPositions>
    {
        bool Exists(int candidateId, Position position);
        CompanyPositions AddPositionToCompany(int companyId, Position position);
    }
}