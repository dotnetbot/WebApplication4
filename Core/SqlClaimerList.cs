using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAbstraction;
using Models;

namespace Core
{
    public class SqlClaimerList: ClaimerList
    {
        IRepositoryFactory _factory;

        public SqlClaimerList(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        public List<Person> Get()
        {
            using (var repository = _factory.MakeRepository())
            {
                return repository.GetAll<Person>().ToList();
            }
        }
    }
}
