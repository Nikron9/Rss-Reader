using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "Rss", action = "Index", id = UrlParameter.Optional},new string[] {"AspNetMVC.Controllers.RssController"}
            );
        }
    }
}