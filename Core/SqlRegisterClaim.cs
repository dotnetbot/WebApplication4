using CoreAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Core
{
    public class SqlRegisterClaim : RegisterClaim
    {
        private IRepositoryFactory _repositoryFactory;

        public SqlRegisterClaim(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public ClaimData Execute(RegisterClaimRequest request)
        {
            if (request.ClaimData == null)
                throw new RegisterClaimException("ClaimData is null. Please, check ClaimData.");

            if (request.ClaimerId == Guid.Empty)
                throw new RegisterClaimException("ClaimData does not have ClaimerId. ClaimerId is necessary.");

            ClaimData claimData = request.ClaimData;

            using (var repository = _repositoryFactory.MakeRepository())
            {
                var claimerData = repository.Find<Person>(request.ClaimerId);
                if (claimerData == null)
                    throw new RegisterClaimException(string.Format("There is not a person with Id = {0}", request.ClaimData.PersonId));

                claimData.StateId = ClaimState.Registered;
                claimerData.Claims.Add(claimData);

                repository.Save();
            }

            return claimData;
        }        
    }
}
