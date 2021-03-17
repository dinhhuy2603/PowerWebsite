using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PowerWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();


            routes.MapRoute(
                name: "Electric1",
                url: "ChartOnline/Electric-1/{action}",
                defaults: new
                {
                    controller = "Electric1",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                name: "Electric2",
                url: "ChartOnline/Electric-2/{action}",
                defaults: new
                {
                    controller = "Electric2",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Gas",
                url: "ChartOnline/Gas/{action}",
                defaults: new
                {
                    controller = "Gas",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                name: "CNG_PC15",
                url: "ChartOnline/Cng-pc-15/{action}",
                defaults: new
                {
                    controller = "Gas",
                    action = "CngPc15",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Water",
                url: "ChartOnline/Water/{action}",
                defaults: new
                {
                    controller = "Water",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                name: "WaterPC15",
                url: "ChartOnline/Water-pc-15/{action}",
                defaults: new
                {
                    controller = "Water",
                    action = "WaterPc15",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                name: "Steam",
                url: "ChartOnline/Steam/{action}",
                defaults: new
                {
                    controller = "Steam",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
            routes.MapRoute(
                name: "Solar",
                url: "ChartOnline/{action}",
                defaults: new
                {
                    controller = "Solar_Logistic",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
