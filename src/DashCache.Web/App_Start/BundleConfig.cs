using System.Web;
using System.Web.Optimization;

namespace DashCache.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                        "~/Scripts/app/js/angular.min.js",
                        "~/Scripts/app/js/angular-route.min.js",
                        "~/Scripts/app/js/angular-resource-min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/appjs").Include(
                        "~/Scripts/app/app.js",
                        "~/Scripts/app/route.js"));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                        "~/Scripts/app/controllers/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
