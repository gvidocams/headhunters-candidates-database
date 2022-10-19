using HeadhuntersCandidatesDatabase.Core.Models;

namespace HeadhuntersCandidatesDatabase.Core.Services
{
    public interface ICompanyPositionService : IEntityService<CompanyPositions>
    {
        CompanyPositions AddPositionToCompany(int companyId, Position position);
    }
}