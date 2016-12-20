using Models;
using System;

namespace CoreAbstraction
{
    public class RegisterClaimRequest
    {
        public Guid ClaimerId;
        public ClaimData ClaimData;
        private ClaimDateProvider _claimDateProvider;

        public RegisterClaimRequest(Guid claimerId, ClaimData claimData, ClaimDateProvider claimDateProvider)
        {
            ClaimerId = claimerId;
            ClaimData = claimData;
            _claimDateProvider = claimDateProvider;
        }       

        public DateTime? GetClaimDate()
        {
            return _claimDateProvider.Get();
        }
    }
}
