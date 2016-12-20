using CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace WebTest
{
    public class ThrowExceptionWhileRegisterClaim : RegisterClaim
    {
        public ClaimData Execute(RegisterClaimRequest request)
        {
            throw new RegisterClaimException();
        }
    }
}
