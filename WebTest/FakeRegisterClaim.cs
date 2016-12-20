using CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Core;

namespace WebTest
{
    public class FakeRegisterClaim : RegisterClaim
    {
        public ClaimData Execute(RegisterClaimRequest request)
        {
            return new ClaimData {
                Id = Guid.NewGuid(),
                StateId = ClaimState.Registered
            };
        }
    }
}
