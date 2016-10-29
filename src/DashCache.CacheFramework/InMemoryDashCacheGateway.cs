using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DashCache.CacheFramework
{
    public sealed class InMemoryDashCacheGateway
    {
        private static readonly InMemoryDashCacheManager _manager = new InMemoryDashCacheManager();

        private InMemoryDashCacheGateway() {
        }

        public static DashCacheItem GetCurrentDashCacheItem()
        {
            return (DashCacheItem)HttpContext.Current.Items["DashCacheItem"];
        }

        public static void SetCurrentDashCacheItem(DashCacheItem currentDashCacheItem)
        {
            HttpContext.Current.Items["DashCacheItem"] = currentDashCacheItem;
        }

        public static void Start(int interval, bool dashCacheEnabled)
        {
            if (dashCacheEnabled)
                _manager.Start(interval);
        }

        public static bool Add(string key, DashCacheItem value)
        {
            return _manager.Add(key, value);
        }

        public static bool Evict(string key)
        {
            return _manager.Evict(key);
        }

        public static DashCacheItem Find(string key)
        {
            return _manager.Find(key);
        }

        public static string GenerateKey(string path, string queryString)
        {
            return _manager.GenerateKey(path, queryString);
        }

        public static bool EvictFirstItemIn()
        {
            return _manager.EvictFirstItemIn();
        }

        public static int GetCacheCount()
        {
            return _manager.GetCacheCount();
        }
    }
}
