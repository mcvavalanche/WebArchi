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
    public class WebApiAutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}