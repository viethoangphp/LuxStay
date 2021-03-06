using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LuxStay
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                   name: "Location",
                   url: "khu-vuc/{id}",
                   defaults: new { controller = "Home", action = "Location", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Rooms",
               url: "Rooms/{id}",
               defaults: new { controller = "Rooms", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "404",
              url: "404",
              defaults: new { controller = "Error", action = "NotFound" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
