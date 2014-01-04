using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ChameleonForms;
using ChameleonForms.Templates.TwitterBootstrap3;
using Raven.Client.Embedded;

namespace DingDing
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.Register(BundleTable.Bundles);
            FormTemplate.Default = new TwitterBootstrapFormTemplate();
        }
    }

    public static class Services
    {
        static Services()
        {
            DocumentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "Data"
            };
            DocumentStore.Initialize();
        }

        public static readonly EmbeddableDocumentStore DocumentStore;
    }
}