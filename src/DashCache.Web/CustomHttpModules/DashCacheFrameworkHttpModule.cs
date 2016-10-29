using DashCache.CacheFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DashCache.Web.CustomHttpModules
{
    public class DashCacheFrameworkHttpModule : DashCacheFrameworkHttpModuleBase
    {
        private string[] _paths = new[] { "/api/students", "/api/course", "/api/values" };

        public override void BeginRequest(object sender, EventArgs e)
        {
            var path = _context.Context.Request.Path;
            var queryString = _context.Request.QueryString.ToString();

            if (_paths.Contains(path) && queryString != string.Empty)
            {
                DashCacheItem dashCacheItem = InMemoryDashCacheGateway.Find(InMemoryDashCacheGateway.GenerateKey(path,queryString));
                InMemoryDashCacheGateway.SetCurrentDashCacheItem(dashCacheItem);
            }
        }


        public override void EndRequest(object sender, EventArgs e)
        {
            var path = _context.Context.Request.Path;
            var queryString = _context.Request.QueryString.ToString();

            if (_paths.Contains(path) && queryString != string.Empty)
            {
                DashCacheItem dashCacheItem = InMemoryDashCacheGateway.GetCurrentDashCacheItem();
                if (dashCacheItem != null && dashCacheItem.IsAlreadyCached != true)
                {
                    dashCacheItem.IsAlreadyCached = true;
                    InMemoryDashCacheGateway.Add(InMemoryDashCacheGateway.GenerateKey(path, queryString), dashCacheItem);
                };
            }

            int count = InMemoryDashCacheGateway.GetCacheCount();
            //read from threshold in config later, don't have the energy to convert
            if (count > 5)
                InMemoryDashCacheGateway.EvictFirstItemIn();
        }
    }
}
