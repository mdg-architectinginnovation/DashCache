using DashCache.CacheFramework.Interfaces;
using DashCache.Common;
using DashCache.Common.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Web;

namespace DashCache.CacheFramework
{
    public sealed class InMemoryDashCacheManager : IDashCacheManager
    {
        private static readonly InMemoryDashCache _cache = new InMemoryDashCache();
        private static readonly InMemoryDashCacheMonitor _monitor = new InMemoryDashCacheMonitor();
        private IDashCacheConfiguration _config = new DashCacheConfiguration(ConfigurationManager.AppSettings);

        public void Start(int interval)
        {
            _monitor.Start(interval, HandleInMemoryDashCacheMonitorElapsedEvent); 
        }

        public bool Add(string key, DashCacheItem value) 
        {
            return _cache.Add(key, value);
        }

        public bool Evict(string key)
        {
            return _cache.Evict(key);
        }

        public DashCacheItem Find(string key)
        {
            return _cache.Find(key);
        }

        public string GenerateKey(string path, string queryString)
        {
            return string.Format("{0}/{1}",path, queryString);
        }

        public bool EvictFirstItemIn()
        {
            bool isRemoved = false;
            string key = _cache.GetOldestItemInCacheKey();
            if (key != string.Empty)
                isRemoved = _cache.Evict(key);

            return isRemoved;
        }

        public void EvictExpiredItems(DateTime currentDateTime, int expiredInMinutes)
        {
            var keys = from cache in
                _cache.FindAll(c => (currentDateTime - c.Value.Timestamp).TotalMinutes >= expiredInMinutes)
                       select cache.Key;

            foreach (var key in keys)
            {
                _cache.Evict(key.ToString());
            }
       }

        public void HandleInMemoryDashCacheMonitorElapsedEvent(Object source, ElapsedEventArgs e)
        {
            EvictExpiredItems(DateTime.Now, _config.Convert("DashCacheExpireCacheItem").ToAInt()); //1 minute, get from config
       }

        public int GetCacheCount()
        {
            return _cache.CacheCount();
        }

        public List<KeyValuePair<string, DashCacheItem>> FindAll(Func<KeyValuePair<string, DashCacheItem>, bool> predicate)
        {
            return _cache.FindAll(predicate);
        }
    }
}
