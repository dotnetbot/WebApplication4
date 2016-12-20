using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace WebApplication4.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API
            // Настройка Web API для использования только проверки подлинности посредством маркера-носителя.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "ApiControllerActionIdentifier",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    constraints: new { action = @"^[a-zA-Z]+$" },
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "ApiControllerAction",
                routeTemplate: "api/{controller}/{action}/",
                defaults: new { action = RouteParameter.Optional },
                constraints: new { action = @"^[a-zA-Z]+$" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            
        }
    }
}
