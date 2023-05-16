using Models.External;

namespace MarkelApi.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Company?> GetCompany(int companyId);
        Task<IEnumerable<BasicClaim>> GetBasicClaims(int companyId);
        Task<EnhancedClaim?> GetEnhancedClaim(string ucr);
        Task UpdateClaim(BasicClaim basicClaim);
    }
}
