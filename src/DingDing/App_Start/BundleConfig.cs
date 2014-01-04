using System.Web.Optimization;

namespace DingDing
{
    public class BundleConfig
    {
        public static void Register(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include("~/Content/bootstrap.css", new BootstrapResourcesTransform())
                .Include("~/Content/toastr.css")
                .IncludeDirectory("~/Content/css/", "*.css", true));
            
            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include("~/Scripts/jquery-2.0.3.js")
                .Include("~/Scripts/jquery-ui-1.10.3.js")
                .Include("~/Scripts/bootstrap.js")
                .Include("~/Scripts/knockout-3.0.0.js")
                .Include("~/Scripts/knockout.validation.js")
                .Include("~/Scripts/toastr.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .IncludeDirectory("~/Scripts/extensions/", "*.js", true)
                .IncludeDirectory("~/Scripts/site/", "*.js", true)
                );
            
            bundles.Add(new ScriptBundle("~/bundles/html5shiv")
                .Include("~/Scripts/html5shiv.js")
                .Include("~/Scripts/respond.js")
                );
        }

        public class BootstrapResourcesTransform : IItemTransform
        {
            public string Process(string includedVirtualPath, string input)
            {
                return input.Replace(@"../fonts/", @"/Content/fonts/")
                    ;
            }
        }
    }
}