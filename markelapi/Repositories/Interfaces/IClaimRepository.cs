using Models.Entities;

namespace MarkelApi.Repositories.Interfaces
{
	public interface IClaimRepository
	{
		Task<IEnumerable<Claim>> GetClaims(int companyId);
        Task<Claim?> GetClaim(string ucr);
        Task<bool> UpdateClaim(Claim claim);
    }
}

