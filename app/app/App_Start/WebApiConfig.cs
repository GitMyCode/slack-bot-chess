using System;
using System.Web.Http;

using Microsoft.Owin.Security.OAuth;

using SLACKBOT.Infrastructure.Serialization;

namespace app
{
    public static class WebApiConfig
    {
        #region Methods

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi", 
                routeTemplate: "api/{controller}/{id}", 
                defaults: new { id = RouteParameter.Optional }
                );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Ensures that the JSON output is in camelCase and handles empty string well.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new EmptyStringContractResolver();
        }

        #endregion
    }
}