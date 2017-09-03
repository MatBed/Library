using System.Web;
using System.Web.Optimization;

namespace Library
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/jquery.easing.min.js",
                        "~/Scripts/jquery.scrollTo.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/animate.min.css",
                      "~/Content/fullwidth.css"));

            bundles.Add(new ScriptBundle("~/bundles/myScripts").Include(
                      "~/Scripts/wow.min.js",
                      "~/Scripts/custom.js"));
        }
    }
}
