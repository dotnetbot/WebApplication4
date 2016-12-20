using CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace WebTest
{
    public class ThrowExceptionWhileRegisterClaimerData : RegisterClaimerData
    {
        public Guid Execute(RegisterClaimerRequest request)
        {
            throw new RegisterClaimerException();
        }
    }
}
