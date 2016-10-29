using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashCache.CacheFramework.Interfaces
{
    internal interface IDashCache
    {
        bool Add(string key, DashCacheItem value);

        bool Evict(string key);

        DashCacheItem Find(string key);

        int CacheCount();

        string GetOldestItemInCacheKey();

        List<KeyValuePair<string, DashCacheItem>> FindAll(Func<KeyValuePair<string, DashCacheItem>,bool> predicate);
    }
}
