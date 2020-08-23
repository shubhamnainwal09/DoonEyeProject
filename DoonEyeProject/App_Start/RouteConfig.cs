using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoonEyeProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { area = "adminuser", controller = "Country", action = "Index", id = UrlParameter.Optional },
                namespaces: new[]{ "DoonEyeProject.Areas.adminuser.Controllers" }
            ).DataTokens["area"] = "adminuser";

           
        }
    }
}
