using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using Castle.Windsor;
using Dota2Stats.Utils;
using System.Web.Http.Dispatcher;
using System.Web.Optimization;

namespace Dota2Stats
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var container = new WindsorContainer();
            container.Install(new ApplicationCastleInstaller());
            var controllerActivator = new CastleControllerActivator(container);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), controllerActivator);

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
