using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using MyNamespace.Web.Auth;
using MyNamespace.Web.Auth.Interfaces;
using Microsoft.AspNet.Identity.Owin;

namespace MyNamespace.WebApi.Infra
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder);
            //builder.Register(c => HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>())
            //.OnActivated(e => (e.Instance).EmailService = e.Context.Resolve<IIdentityMessageService>())
            //.As<IUserManager>();

            builder.Register(c => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>()).As<ISignInManager>();

        }
    }
}