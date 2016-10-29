using DashCache.CacheFramework;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashCache.Unit.Tests
{
    [TestFixture]
    public class InMemoryDashCacheManagerTests
    {
        [Test]
        public void InMemoryDashCacheManagerCanAddTest()
        {
            //given
            InMemoryDashCacheManager manager = new InMemoryDashCacheManager();
            manager.Add("item1", new DashCacheItem(new object()));
            manager.Add("item2", new DashCacheItem(new object()));
            manager.Add("item3", new DashCacheItem(new object()));
            //when
            int count = manager.GetCacheCount();
            //then
            count.Should().Be(3);
        }

        [Test]
        public void InMemoryDashCacheManagerCanEvictTest()
        {
            //given
            InMemoryDashCacheManager manager = new InMemoryDashCacheManager();
            manager.Add("item1", new DashCacheItem(new object()));
            manager.Add("item2", new DashCacheItem(new object()));
            manager.Add("item3", new DashCacheItem(new object()));
            //when
            bool isEvicted= manager.Evict("item2");
            //then
            isEvicted.Should().BeTrue();
        }

        [Test]
        public void InMemoryDashCacheManagerCanFindTest()
        {
            //given
            string key = "DateFilter=4/24/2015;4/24/2016&DataFilter=AuditType/Complex&SourceOrgType=CMS&Axis=Month,Year&ProductLine/DME 1st Pass";
            InMemoryDashCacheManager manager = new InMemoryDashCacheManager();
            manager.Add("item1", new DashCacheItem(new object()));
            manager.Add("item2", new DashCacheItem(new object()));
            manager.Add(key, new DashCacheItem(new object()));
            //when
            DashCacheItem item = manager.Find(key);
            //then
            item.Should().Equals(manager.Find(key));
        }

        [Test]
        public void InMemoryDashCacheManagerCanFindAllTest()
        {
            //given
            InMemoryDashCacheManager manager = new InMemoryDashCacheManager();
            manager.Add("item1", new DashCacheItem(new object()));
            manager.Add("item2", new DashCacheItem(new object()));
            manager.Add("item3", new DashCacheItem(new object()));
            //when
            var items = manager.FindAll(c => c.Key == "item1" || c.Key == "item3");
            //then
            items.Count().Should().Be(2);
        }

        [Test]
        public void InMemoryDashCacheManagerCanEvictExpiredItemsTest()
        {
            //given
            InMemoryDashCacheManager manager = new InMemoryDashCacheManager();
            manager.Add("item1", new DashCacheItem(new object()));
            manager.Add("item2", new DashCacheItem(new object()));
            manager.Add("item3", new DashCacheItem(new object()));
            //when
            int expiredInHours = 5;
            DateTime currentDateTime = DateTime.Now.AddHours(7);
            manager.EvictExpiredItems(currentDateTime, expiredInHours);
            //then
            manager.GetCacheCount().Should().Be(0);
        }
    }
}
