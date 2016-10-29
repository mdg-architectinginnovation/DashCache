using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashCache.CacheFramework.Interfaces
{
    public interface IDashCacheManager
    {
        int GetCacheCount();

        void Start(int interval);

        bool Add(string key, DashCacheItem value);

        bool Evict(string key);

        DashCacheItem Find(string key);

        string GenerateKey(string path, string queryString);

        bool EvictFirstItemIn();

        List<KeyValuePair<string, DashCacheItem>> FindAll(Func<KeyValuePair<string, DashCacheItem>, bool> predicate);
    }
}
