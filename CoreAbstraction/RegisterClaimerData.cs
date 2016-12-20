using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAbstraction
{
    public interface RegisterClaimerData
    {
        Guid Execute(RegisterClaimerRequest request);        
    }
}
