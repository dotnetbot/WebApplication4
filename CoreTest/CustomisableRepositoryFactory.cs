using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest
{
    public class CustomisableRepositoryFactory<T>: IRepositoryFactory where T: class
    {
        InMemoryRepository<T> _repository;

        public CustomisableRepositoryFactory(List<T> items)
        {
            _repository = new InMemoryRepository<T>();
            _repository.CustomItems = items;
        }

        public IRepository MakeRepository()
        {
            return _repository;
        }
    }
}
