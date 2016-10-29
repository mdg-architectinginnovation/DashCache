using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DashCache.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);

        IEnumerable<T> FindAll(Expression<Func<T,bool>> predicate);
    }
}
