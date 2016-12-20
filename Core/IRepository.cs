using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core
{
    /// <summary>
    /// Интерфейс репозитория.
    /// Если метод содержит слово Save то изменения вносятся в базу сразу
    /// Если нужно вызвать несколько методов подряд, 
    /// то надо использовать методы без слова Save, 
    /// а после вызвать метод Save чтобы изменения зафиксировались в базе
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial interface IRepository : IDisposable
    {
        //IQueryable<T> All<T> { get; }
        T Find<T>(params object[] keyValues) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        void Edit<T>(T oldEntity, T entity) where T : class;
        void Edit<T>(T entity) where T : class;
        void Save();
    }
}
