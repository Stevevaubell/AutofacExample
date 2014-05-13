using Autofac;
using Autofac.Integration.Mvc;
using AutofacExample.Web.Ioc;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AutofacExample.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetupAutoFac();
        }

        private void SetupAutoFac()
        {
            var dependencyBuilder = new DependencySetup();

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            var container = builder.Build();

            dependencyBuilder.AddDependencies(container, ConfigurationManager.ConnectionStrings["Example"].ConnectionString);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
