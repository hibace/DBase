using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Dota2Stats
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
           // config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Dota2Stats",
                routeTemplate: "Dota2Stats/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
