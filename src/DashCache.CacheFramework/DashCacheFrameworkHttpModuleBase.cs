using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DashCache.Common;
using DashCache.Common.Interfaces;

namespace DashCache.CacheFramework
{
    public abstract class DashCacheFrameworkHttpModuleBase : IHttpModule
    {
        protected HttpApplication _context;
        protected readonly IDashCacheConfiguration _config = new DashCacheConfiguration(ConfigurationManager.AppSettings);
        public void Dispose() {
        }

        public void Init(HttpApplication context)
        {
            _context = context;

            context.BeginRequest += (sender, e) =>
            {
                if (_config.Convert("DashCacheEnabled").ToABool())
                    BeginRequest(sender, e);
            };

            context.EndRequest += (sender, e) =>
            {
                if (_config.Convert("DashCacheEnabled").ToABool()) 
                    EndRequest(sender, e);
            };
        }

        public abstract void BeginRequest(object sender, EventArgs e);

        public abstract void EndRequest(object sender, EventArgs e);

    }
}
