using DashCache.CacheFramework;
using DashCache.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DashCache.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var _config = new DashCacheConfiguration(ConfigurationManager.AppSettings);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InMemoryDashCacheGateway.Start(_config.Convert("DashCacheMonitorInterval").ToAInt(), _config.Convert("DashCacheEnabled").ToABool()); //30 seconds and dash cache enabled, get from config
        }
    }
}
