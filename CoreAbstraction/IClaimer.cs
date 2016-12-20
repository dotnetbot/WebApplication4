using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAbstraction
{
    public interface IClaimer
    {
        Guid Id { get; }
        IClaim MakeClaim(ClaimData claimData);
    }
}
