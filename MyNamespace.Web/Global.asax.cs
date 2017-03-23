using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MyNamespace.DataAccess.EF.Infra;
using MyNamespace.Web.Infra;

namespace MyNamespace.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetupAutofacContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void SetupAutofacContainer()
        {
            var builder = new ContainerBuilder();
            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();
            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());
            
            // Register Modules
            //builder.RegisterModule(new WebAutofacModule());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new DataAccessAutofacModule("name=Entities"));

            var container = builder.Build();
            
            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
