using DashCache.Common.Interfaces;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DashCache.Common
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            For<IDashCacheConfiguration>().Use<DashCacheConfiguration>().Ctor<NameValueCollection>().Is(ConfigurationManager.AppSettings);
        }
    }
}
