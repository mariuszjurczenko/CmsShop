using System.Web;
using System.Web.Optimization;

namespace CmsShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                       "~/Scripts/jquery-{version}.js",
                       "~/Scripts/bootstrap.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/admin-lte/js").Include(
                      "~/admin-lte/js/adminlte.js",
                      "~/admin-lte/plugins/fastclick/fastclick.js",
                      "~/admin-lte/plugins/datatables/jquery.dataTables.js",
                      "~/admin-lte/plugins/datatables/dataTables.bootstrap.js",
                      "~/admin-lte/plugins/chartjs/Chart.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/font-awesome.css",
                      "~/Content/ionicons.css",
                      "~/admin-lte/css/AdminLTE.css",
                      "~/admin-lte/css/skins/skin-blue.css",
                      "~/admin-lte/plugins/datatables/dataTables.bootstrap.css"));
        }
    }
}
