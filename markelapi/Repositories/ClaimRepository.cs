using MarkelApi.Repositories.Interfaces;
using Models.Entities;

namespace MarkelApi.Repositories
{
	public class ClaimRepository : IClaimRepository
    {
        private static readonly List<Claim> _claims;

        static ClaimRepository()
		{
            _claims = new List<Claim>
            {
                new Claim
                {
                    UCR = "SomeUCR",
                    CompanyId = 1,
                    ClaimDate = DateTime.UtcNow.AddMonths(6),
                    LossDate = DateTime.UtcNow.AddMonths(5),
                    AssuredName = "Simmonds",
                    IncurredLoss = 5.50m,
                    Closed = true
                },
                new Claim
                {
                    UCR = "AnotherUCR",
                    CompanyId = 1,
                    ClaimDate = DateTime.UtcNow.AddMonths(12),
                    LossDate = DateTime.UtcNow.AddMonths(11),
                    AssuredName = "Hammond",
                    IncurredLoss = 125m,
                    Closed = true
                },
                new Claim
                {
                    UCR = "RedFlagUCR",
                    CompanyId = 2,
                    ClaimDate = DateTime.UtcNow.AddMonths(8),
                    LossDate = DateTime.UtcNow.AddMonths(8),
                    AssuredName = "VanityFair",
                    IncurredLoss = 0m,
                    Closed = true
                },
                new Claim
                {
                    UCR = "BigMoneyUCR",
                    CompanyId = 3,
                    ClaimDate = DateTime.UtcNow,
                    LossDate = DateTime.UtcNow,
                    AssuredName = "Elkie",
                    IncurredLoss = 1.99m,
                    Closed = false
                }
            };
        }

        public async Task<IEnumerable<Claim>> GetClaims(int companyId)
        {
            var claims = await Task.Run<IEnumerable<Claim>>(() => _claims.Where(x => x.CompanyId == companyId).ToList());
            return claims;
        }

        public async Task<Claim?> GetClaim(string ucr)
        {
            var claim = await Task.Run(() => _claims.SingleOrDefault(x => x.UCR == ucr));
            return claim;
        }

        public async Task<bool> UpdateClaim(Claim claim)
        {
            var claimToUpdate = await Task.Run(() => _claims.Single(x => x.UCR == claim.UCR));

            claimToUpdate.AssuredName = claim.AssuredName;
            claimToUpdate.ClaimDate = claim.ClaimDate;
            claimToUpdate.Closed = claim.Closed;
            claimToUpdate.IncurredLoss = claim.IncurredLoss;
            claimToUpdate.LossDate = claim.LossDate;

            return true;
        }
    }
}

