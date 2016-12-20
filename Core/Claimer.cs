using CoreAbstraction;
using Models;
using System;

namespace Core
{
    public class Claimer
    {
        private Person _claimerData;
        public Guid Id { get; private set; }

        public Claimer(Guid id, Person claimerData)
        {
            Id = id;
            _claimerData = claimerData;
        }

        public Claim MakeClaim(ClaimData claimData)
        {

            var claim = new Claim(Id, claimData);
            return claim;
        }
    }
}