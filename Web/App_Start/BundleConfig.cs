using System.Web.Optimization;

namespace Web
{

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/Jquery").Include(
            "~/Scripts/core/jquery-1.9.1.min.js"
             ));

            bundles.Add(new ScriptBundle("~/scripts/angular").Include(
             "~/Scripts/core/angular.min.js",
             "~/Scripts/core/angular-sanitize.min.js",
             "~/Scripts/core/angular-ui-router.min.js",
             "~/Scripts/bower/angular-translate-loader-partial/angular-translate.min.js",
             "~/Scripts/bower/blockui/angular-block-ui.js",
             "~/Scripts/bower/angular-translate-loader-partial/angular-translate-loader-partial/angular-translate-loader-partial.min.js"
            
             ));

            bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
                      "~/Scripts/bower/bootstrap/bootstrap.min.js",
                      "~/Scripts/bower/bootstrap/ui-bootstrap/ui-bootstrap-tpls-0.12.0.js"
                    ));

            bundles.Add(new ScriptBundle("~/scripts/kendo").Include(
               "~/Scripts/bower/date/JalaliDate.js",
               "~/Scripts/bower/date/moment.min.js",
               "~/Scripts/bower/date/moment-jalaali.js",
               "~/Scripts/bower/kendo/kendo.web.min.js",
               "~/Scripts/bower_components/kendo/cultures/kendo.fa-IR.js",
               "~/Scripts/bower_components/kendo/kendo.angular.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/modernizr").Include("~/Scripts/modernizr.js"));

            bundles.Add(new StyleBundle("~/content/bootstrap").Include(
                     "~/Content/bootstrap/css/bootstrap.min.css",
                      "~/Content/bootstrap/css/Bootstrap-rtl.css",
                     "~/Content/kendoUI/kendo.common.min.css",
                     "~/Content/kendoUI/kendo.default.min.css",
                     "~/Content/kendoUI/kendo.rtl.min.css",
                     "~/Content/blockui/angular-block-ui.min.css"
                    ));

            bundles.Add(new StyleBundle("~/fonts").Include(
                    "~/Content/FortAwesome/css/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/content/main").Include(
                "~/Content/main/index.css"));


        }
    }
}
