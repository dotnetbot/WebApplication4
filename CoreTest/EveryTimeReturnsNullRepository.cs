using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CoreTest
{
    public class EveryTimeReturnsNullRepository : IRepository
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
            return null;
        }

        public IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return null;
        }

        public IQueryable<T> GetAll<T>() where T : class
        {
            return null;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
