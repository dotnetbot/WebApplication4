using Models;

namespace CoreAbstraction
{
    public interface RegisterClaim
    {
        ClaimData Execute(RegisterClaimRequest request);
    }
}
