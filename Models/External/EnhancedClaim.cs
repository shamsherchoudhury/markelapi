using System;
using Models.Entities;

namespace Models.External
{
	public class EnhancedClaim : BasicClaim
	{
		public EnhancedClaim(BasicClaim claim)
		{
            UCR = claim.UCR;
            ClaimDate = claim.ClaimDate;
            LossDate = claim.LossDate;
            AssuredName = claim.AssuredName;
            IncurredLoss = claim.IncurredLoss;
            Closed = claim.Closed;

            ///BREAKDOWN: this does not work if the claim is closed, there is no field for when this happened, if there was it should replace DateTime.UtcNow
            ClaimDurationInDays = (DateTime.UtcNow - ClaimDate).Days;
        }

        public int ClaimDurationInDays { get; set; }
	}
}

