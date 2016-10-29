using DashCache.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashCache.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Student> Students { get; }
        IRepository<Course> Courses { get; }
        IRepository<StudentsCourses> StudentsCourses { get; }
        int Save();
    }
}
