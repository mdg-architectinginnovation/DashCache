using DashCache.CacheFramework;
using DashCache.Domain.Entities;
using DashCache.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DashCache.Web.Controllers
{
    public class StudentsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Student
        public object Get()
        {
            var dashCacheItem = InMemoryDashCacheGateway.GetCurrentDashCacheItem();
            if (dashCacheItem == null)
            {
                var students = _unitOfWork.Students.FindAll(s => s.StudentId <= 300);
                InMemoryDashCacheGateway.SetCurrentDashCacheItem(new DashCacheItem(students.ToList()));
                return students;
            }
            else
            {
                return dashCacheItem.GetCachedItem<List<Student>>();
            }
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
