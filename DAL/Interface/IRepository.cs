using System;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
