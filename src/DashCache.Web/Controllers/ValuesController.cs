using DashCache.CacheFramework;
using DashCache.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DashCache.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET api/values
        public object Get()
        {
            var dashCacheItem = InMemoryDashCacheGateway.GetCurrentDashCacheItem();
            if (dashCacheItem == null)
            {
                var values = new string[] { "value1", "value2","value3" };
                InMemoryDashCacheGateway.SetCurrentDashCacheItem(new DashCacheItem(values));
                return values;
            }
            else
            {
                return dashCacheItem.GetCachedItem<string[]>();
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
