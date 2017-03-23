using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using MyNamespace.DataAccess.EF.Infra;

namespace MyNamespace.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SetupAutofacContainer();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void SetupAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //register Modules
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new DataAccessAutofacModule("name=Entities"));

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
