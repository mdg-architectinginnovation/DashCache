using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DashCache.CacheFramework.Interfaces;

namespace DashCache.CacheFramework
{
    public sealed class DashCacheItem
    {
        private object _cachedItem;
        private DateTime _timestamp;
        private bool _isAlreadyCached;

        public DateTime Timestamp { get { return _timestamp; }}

        public bool IsAlreadyCached { get { return _isAlreadyCached; } set { _isAlreadyCached = value; } }

        public DashCacheItem(object cachedItem)
        {
            _cachedItem = cachedItem;
            _timestamp = DateTime.Now;
            _isAlreadyCached = false;
        }

        public T GetCachedItem<T>() where T : class
        {
            return (T)_cachedItem;
        }
    }
}
