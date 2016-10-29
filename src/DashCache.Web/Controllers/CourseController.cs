using DashCache.CacheFramework;
using DashCache.Domain.Entities;
using DashCache.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DashCache.Web.Controllers
{
    public class CourseController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/Course
        public object Get()
        {
            var dashCacheItem = InMemoryDashCacheGateway.GetCurrentDashCacheItem();
            if (dashCacheItem == null)
            {
                var courses = _unitOfWork.Courses.FindAll(c => c.CourseId <= 300);
                InMemoryDashCacheGateway.SetCurrentDashCacheItem(new DashCacheItem(courses.ToList()));
                return courses;
            }
            else
            {
                return dashCacheItem.GetCachedItem<List<Course>>();
            }
        }

        // GET: api/Course/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Course
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Course/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Course/5
        public void Delete(int id)
        {
        }
    }
}
