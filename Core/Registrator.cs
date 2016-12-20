using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Registrator
    {
        private IRepositoryFactory _repositoryFactory;

        public Registrator(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        //public Claim Register(Claim claim)
        //{
        //    claim.setState(RegisterStateId);



        //    return claim;
        //}
    }
}
