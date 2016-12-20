using CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class NowClaimDateProvider : ClaimDateProvider
    {
        public DateTime? Get()
        {
            return DateTime.Now;
        }
    }
}
