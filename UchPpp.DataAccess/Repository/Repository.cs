﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UchPpp.DataAccess.Repository.Irepository;

namespace UchPpp.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
      private readonly PppDbContext _db;
        internal DbSet<T> dbSet;

          public Repository(PppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();  
        }
        public void Add(T entity)
        {
            dbSet.Add(entity); 
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();       
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet = Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet= RemoveRange(entity);
        }
    }
}