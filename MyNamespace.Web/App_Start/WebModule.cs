using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;

namespace MyNamespace.Web
{
    public class WebModule : Module
    {
        private string connStr;
        public WebModule(string connString)
        {
            this.connStr = connString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c => new EFContext(this.connStr)).As<IDbContext>().InstancePerRequest();

            //builder.RegisterType<SqlRepository>().As<IRepository>().InstancePerRequest();
            //builder.RegisterType<TeamRepository>().As<ITeamRepository>().InstancePerRequest();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            base.Load(builder);
        }
    }
    
}