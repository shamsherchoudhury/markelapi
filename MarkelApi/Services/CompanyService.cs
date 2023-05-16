using MarkelApi.Services.Interfaces;
using Models.External;
using MarkelApi.Repositories.Interfaces;
using System.Data;
using Models.Exceptions;

namespace MarkelApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IClaimRepository _claimRepository;

        public CompanyService(ICompanyRepository companyRepository, IClaimRepository claimRepository)
        {
            _companyRepository = companyRepository;
            _claimRepository = claimRepository;
        }

        public async Task<Company?> GetCompany(int companyId)
        {
            var entity = await _companyRepository.GetCompany(companyId);

            if (entity is not null)
            {
                return new Company
                {
                    Name = entity.Name,
                    Address1 = entity.Address1,
                    Address2 = entity.Address2,
                    Address3 = entity.Address3,
                    Postcode = entity.Postcode,
                    Country = entity.Country,
                    IsPolicyActive = entity.InsuranceEndDate > DateTime.UtcNow
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<BasicClaim>> GetBasicClaims(int companyId)
        {
            var claims = await _claimRepository.GetClaims(companyId);

            return claims.Select(x => new BasicClaim
                {
                    AssuredName = x.AssuredName,
                    ClaimDate = x.ClaimDate,
                    UCR = x.UCR,
                    Closed = x.Closed,
                    IncurredLoss = x.IncurredLoss,
                    LossDate = x.LossDate
                }
            ).ToList();
        }

        public async Task<EnhancedClaim?> GetEnhancedClaim(string ucr)
        {
            EnhancedClaim? enhancedClaim = null;

            var claim = await _claimRepository.GetClaim(ucr);

            if (claim is not null)
            {
                var basicClaim = new BasicClaim
                {
                    AssuredName = claim.AssuredName,
                    ClaimDate = claim.ClaimDate,
                    UCR = claim.UCR,
                    Closed = claim.Closed,
                    IncurredLoss = claim.IncurredLoss,
                    LossDate = claim.LossDate
                };

                enhancedClaim = new EnhancedClaim(basicClaim);
            }

            return enhancedClaim;
        }

        public async Task UpdateClaim(BasicClaim basicClaim)
        {

            var claim = await _claimRepository.GetClaim(basicClaim.UCR);

            if (claim is not null)
            {
                var entity = new Models.Entities.Claim
                {
                    AssuredName = basicClaim.AssuredName,
                    ClaimDate = basicClaim.ClaimDate,
                    UCR = basicClaim.UCR,
                    Closed = basicClaim.Closed,
                    IncurredLoss = basicClaim.IncurredLoss,
                    LossDate = basicClaim.LossDate
                };

                await _claimRepository.UpdateClaim(entity);
            }
            else
            {
                throw new EntityNotFoundException($"No claim with UCR:{basicClaim.UCR}");
            }          
        }
    }
}

