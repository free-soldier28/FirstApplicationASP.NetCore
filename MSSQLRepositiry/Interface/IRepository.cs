using DAL;
using System;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IRepository<T> 
        where T: BaseEntity 
    {
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
