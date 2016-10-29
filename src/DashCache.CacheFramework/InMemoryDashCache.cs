using DashCache.CacheFramework.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashCache.CacheFramework
{
    internal sealed class InMemoryDashCache : IDashCache
    {
        private ConcurrentDictionary<string, DashCacheItem> _cache = new ConcurrentDictionary<string, DashCacheItem>();

        public bool Add(string key, DashCacheItem value)
        {
            bool isAdded = _cache.TryAdd(key, value);
            return isAdded;
        }

        public DashCacheItem Find(string key)
        {
            DashCacheItem item;
            _cache.TryGetValue(key, out item);
            return item;
        }

        public bool Evict(string key)
        {
            DashCacheItem item;
            bool isRemoved = _cache.TryRemove(key, out item);
            return isRemoved;
        }

        public int CacheCount()
        {
            return _cache.Count();
        }

        public string GetOldestItemInCacheKey()
        {
            string key = string.Empty;
            try
            {
                if (_cache.Count() > 0)
                {
                    key = _cache.OrderBy(v => v.Value.Timestamp).FirstOrDefault().Key;
                }
            }
            catch (Exception) {
            }
            return key;
        }

        public List<KeyValuePair<string, DashCacheItem>> FindAll(Func<KeyValuePair<string, DashCacheItem>, bool> predicate)
        {
            var items = _cache.Where(predicate);
            if (items != null)
                return items.ToList();
            else
                return null;
        }
    }
}
