using CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTest
{
    public class FakeClaimDateProvider : ClaimDateProvider
    {
        public DateTime? Get()
        {
            return DateTime.Now;
        }
    }
}
