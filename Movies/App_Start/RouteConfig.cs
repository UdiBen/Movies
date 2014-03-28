using Movies.Controllers;
using Movies.Infrastructure;
using Raven.Abstractions.Extensions;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
namespace Movies
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			Assembly.GetAssembly(typeof(HomeController)).GetTypes()
				.Where(x=>typeof(Controller).IsAssignableFrom(x))
				.ForEach(type =>
				{
					var methods = type.GetMethods()
						.ToDictionary(x=>x, x => Attribute.GetCustomAttribute(x, typeof (PatternRouteAttribute)) as PatternRouteAttribute)
						.Where(x=>x.Value != null);
					methods.ForEach(x=>
						routes.MapRoute(x.Key.Name, x.Value.Url, new { controller = "Home", action = x.Key.Name, id = UrlParameter.Optional }));
				});
			

//			routes.MapRoute(
//				name: "Default",
//				url: "{controller}/{action}/{id}",
//				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
//			);
		}
	}
}