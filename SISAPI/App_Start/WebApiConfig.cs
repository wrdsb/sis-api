using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SISAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //TEST code makes auth needed on all actions
            //not sure if using this method yet so remove so if needed
            //config.Filters.Add(new AuthorizeAttribute());

            //Enabling CORS
            //Install-Package Microsoft.Asp.Net.WebApi.Cors
            //config.EnableCors();
            //In the controller:
            //using System.Web.Http.Cors;
            //[EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
            //URI where you deployed the WebClient application
            //see for more details: http://www.asp.net/web-api/overview/security/enabling-cross-origin-requests-in-web-api

            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
