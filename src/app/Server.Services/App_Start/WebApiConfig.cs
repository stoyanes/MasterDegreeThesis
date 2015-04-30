using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;

namespace Server.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

//            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(new EnableCorsAttribute("http://localhost:21620", "*", "*"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            SetJsonSettings(config);

            // we currently don't want xml to be returned
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }

        /// <summary>
        /// This method updates formatting to the .NET objects to JavaScript style ones i.e. from PascalCase to camelCase  
        /// </summary>
        private static void SetJsonSettings(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
