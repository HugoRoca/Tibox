using System.Web;
using System.Web.Optimization;

namespace Tibox.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/style.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.js")
                .Include("~/Scripts/angular-ui-router.js"));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/app/app.js")
                .Include("~/app/app.routes.js")
                );
        }
    }
}
