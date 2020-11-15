using BilgeAdam.NTier.ERP.Data.Context;
using BilgeAdam.NTier.ERP.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BilgeAdam.NTier.ERP.Data.Access
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly NorthwinDbContext context;
        private readonly DbSet<T> table;
        public Repository()
        {
            context = new NorthwinDbContext();
            table = context.Set<T>();
        }
        public Expression Expression { get { return table.AsQueryable().Expression; } }

        public Type ElementType => table.AsQueryable().ElementType;

        public IQueryProvider Provider => table.AsQueryable().Provider;

        public void Add(T entity)
        {
            table.Add(entity);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return table.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return table.AsEnumerable().GetEnumerator();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
