using DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private DbContext _db;
        private DbSet<T> _dbSet;
        private bool disposedValue = false;

        public Repository(DbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            IEnumerable<T> list = null;

            if (predicate != null)
            {
                list = _dbSet.Where(predicate).ToList();
            }
            return list;
        }

        public T GetById(int id)
        {
            T obj = null;

            if (id != 0)
            {
                obj = _dbSet.Find(id);
            }
            return obj;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Create(T obj)
        {
            try
            {
                if (obj != null)
                {
                    _dbSet.Add(obj);
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void Update(T obj)
        {
            try
            {
                if (obj != null)
                {
                    _db.Entry(obj).State = EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            catch (Exception)
            {

            }
        }

        public void Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    T obj = _dbSet.Find(id);
                    if (obj != null)
                    {
                        _dbSet.Remove(obj);
                        _db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                if (disposing)
                {
                    _db.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
