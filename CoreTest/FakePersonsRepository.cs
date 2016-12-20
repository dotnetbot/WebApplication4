using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Models;

namespace CoreTest
{
    public class FakePersonsRepository : IRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(params object[] keyValues) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            ;
        }

        public void Edit<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Edit<T>(T oldEntity, T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public T Find<T>(params object[] keyValues) where T : class
        {
            var id = (Guid)keyValues[0];
            if (typeof(T) == typeof(Person))
            {
                var result = new Person()
                {
                    Id = id,
                    Claims = new List<ClaimData>()
                };

                return result as T;
            }

            return null;
        }

        public IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            ;
        }
    }
}
