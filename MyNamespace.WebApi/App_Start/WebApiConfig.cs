using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using MyNamespace.DataAccess.Model;
using MyNamespace.Web.Auth;
using MyNamespace.WebApi.Models;

namespace MyNamespace.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //configure serialization and media types per formatter

            //example of how to disable the DataContractSerializer and use the XmlSerializer instead. this will give more flexibility for the xml serialization
            //config.Formatters.XmlFormatter.UseXmlSerializer = true;

            //example of how to register a type as known type for the xml DataContractSerializer
            //config.Formatters.XmlFormatter.SetSerializer<AspNetUsers>(new DataContractSerializer(typeof(AspNetUsers) ,new Type[] { typeof(AspNetUsers) }));

            //handle text/html requests with the json formatter (return a json response). this will be the default when making a request from the browser without a specific Content-Type.
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
