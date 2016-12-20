using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest
{
    public class FakeRepositoryFactory : IRepositoryFactory
    {
        public IRepository MakeRepository()
        {
            return new FakeRepository();
        }
    }
}
