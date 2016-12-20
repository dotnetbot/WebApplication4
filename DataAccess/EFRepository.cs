using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.SqlClient;
using Core;

namespace DataAccess
{
    public partial class EFRepository : IRepository
    {
        protected DbContext DbContext { get; set; }

        protected ObjectContext ObjectContext { get; set; }

        public EFRepository(ObjectContext context)
        {
            DbContext = new DbContext(context, true);
            ObjectContext = context;
        }

        //При создании класса через DbContext - функция выполнения хранимых процедур будет недоступна.
        public EFRepository(DbContext context)
        {
            DbContext = context;
        }

        public virtual IQueryable<T> GetAll<T>() where T: class
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public virtual T Find<T>(params object[] keyValues) where T : class
        {
            return DbContext.Set<T>().Find(keyValues);
        }

        public virtual IQueryable<T> FindBy<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class
        {
            var query = ObjectContext.CreateObjectSet<T>().Where(predicate);
            //IQueryable<T> query = DbContext.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add<T>(T entity) where T : class
        {
            DbContext.Set<T>().Add(entity);
        }
                
        public virtual void Delete<T>(T entity) where T : class
        {
            DbContext.Set<T>().Remove(entity);
        }

        public virtual void Delete<T>(params object[] keyValues) where T : class
        {
            var entity = Find<T>(keyValues);
            Delete(entity);
        }

        public virtual void Edit<T>(T oldEntity, T entity) where T : class
        {
            DbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
        }

        public virtual void Edit<T>(T entity) where T : class
        {
            //var typedEntity = entity as EntityObject;
            //var oldEntity = Find(typedEntity.EntityKey.EntityKeyValues.Select(ek => ek.Value).ToArray());
            //DbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            DbContext.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
                if (disposing)
                    DbContext.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        
    }
}
