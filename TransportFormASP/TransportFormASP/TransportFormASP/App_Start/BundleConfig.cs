using System.Web;
using System.Web.Optimization;

namespace TransportFormASP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.3.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
                       ));
            bundles.Add(new ScriptBundle("~/bundles/jquery-globalize").Include(
                        "~/Scripts/globalize.js",
                        "~/Scripts/i18n/@(System.Threading.Thread.CurrentThread.CurrentCulture.Name).js"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                       "~/Scripts/select2.min.js",
                       "~/Scripts/selecthandler.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-ui").Include(
                        "~/Scripts/jquery-ui-1.12.1.min.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/css/select2.min.css",
                       "~/Content/site.css",
                       "~/Content/themes/base/jquery-ui.min.css"));
        }
    }
}
