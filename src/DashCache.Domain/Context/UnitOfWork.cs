using DashCache.Domain.Entities;
using DashCache.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashCache.Domain.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private SchoolDbContext _context;

        private IRepository<Student> _students;
        private IRepository<Course> _courses;
        private IRepository<StudentsCourses> _studentsCourses;

        public UnitOfWork(SchoolDbContext context)
        {
            _context = context;
        }
        public IRepository<Course> Courses
        {
            get
            {
                if (_courses == null)
                    _courses = new Repository<Course>(_context);
                return _courses;
            }
        }

        public IRepository<Student> Students
        {
            get
            {
                if (_students == null)
                _students = new Repository<Student>(_context);

                return _students;
            }
        }

        public IRepository<StudentsCourses> StudentsCourses
        {
            get
            {
                if (_studentsCourses == null)
                    _studentsCourses = new Repository<StudentsCourses>(_context);
                return _studentsCourses;
            }
        }

        public int Save()
        {
            int status = _context.SaveChanges();
            return status;
        }
    }
}
