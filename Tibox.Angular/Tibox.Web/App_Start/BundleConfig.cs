﻿using System.Web;
using System.Web.Optimization;

namespace Tibox.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/boostrap")
                .IncludeDirectory("~/Content/bootstrap/css", "*.css"));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/site.css")
                );

            bundles.Add(new ScriptBundle("~/bundlee/bootstrapjs")
                .Include("~/Scripts/jquery.js")
                .Include("~/Content/bootstrsp/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.js")
                .IncludeDirectory("~/Scripts/modules", "*.js", true));

            bundles.Add(new ScriptBundle("~/bundles/app")
                .Include("~/app/app.js")
                .Include("~/app/app.routes.js")
                .Include("~/app/app.config.js")
                .Include("~/app/app.controller.js")               

                .IncludeDirectory("~/app/shared","*.js", true)
                .IncludeDirectory("~/app/private", "*.js", true)
                .IncludeDirectory("~/app/public", "*.js", true)
                );
        }
    }
}
