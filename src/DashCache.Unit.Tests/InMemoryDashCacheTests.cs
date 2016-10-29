using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashCache.CacheFramework;
using DashCache.CacheFramework.Interfaces;

namespace DashCache.Unit.Tests
{
    [TestFixture]
    public class InMemoryDashCacheTests
    {
        [Test]
        public void InMemoryDashCacheCanGetOldestItemInCacheKeyTest()
        {
            //given
            IDashCache cache = new InMemoryDashCache();
            string id1 = Guid.NewGuid().ToString();
            cache.Add(id1, new DashCacheItem(new object()));
            //when
            string key = cache.GetOldestItemInCacheKey();
            //then
            key.Should().BeEquivalentTo(id1);
        }

        [Test]
        public void InMemoryDashCacheCanFindAll()
        {
            //given
            InMemoryDashCache cache = new InMemoryDashCache();
            string id1 = Guid.NewGuid().ToString();
            string id2 = Guid.NewGuid().ToString();
            string id3 = Guid.NewGuid().ToString();
            cache.Add(id1, new DashCacheItem(new object()) { IsAlreadyCached = true });
            cache.Add(id2, new DashCacheItem(new object()) { IsAlreadyCached = false });
            cache.Add(id3, new DashCacheItem(new object()) { IsAlreadyCached = true });
            //when
            var items = cache.FindAll(c => c.Value.IsAlreadyCached == true);
            //then
            items.Count().Should().Be(2);
        }
    }
}
