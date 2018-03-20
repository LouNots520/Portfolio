using System.Web.Mvc;
using System.Web.Routing;

namespace BusinessIntelligenceDashboard
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Login", action = "Login" }
            );
            routes.MapRoute(
                name: "DeleteGraph",
                url: "{controller}/{action}/{dashboardname}/{id}",
                defaults: new { controller = "Graph", action = "DeleteGraph", dashboardname = "", id = "" }
            );
            routes.MapRoute(
                name: "DashCreateOrDelete",
                url: "{controller}/{action}/{dashboardname}",
                defaults: new { controller = "Graph", action = "", dashboardname = "" }
            );
            routes.MapRoute(
                name: "DuplicateDash",
                url: "{controller}/{action}/{dashboardname}/{newName}",
                defaults: new { controller = "Graph", action = "Duplicate", dashboardname = "", newName = "" }
            );
        }
    }
}
