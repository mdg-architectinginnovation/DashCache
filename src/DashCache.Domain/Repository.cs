using DashCache.Domain.Context;
using DashCache.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DashCache.Domain
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private SchoolDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(SchoolDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate) 
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
