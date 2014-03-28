using Castle.Windsor;
using Castle.Windsor.Installer;
using Movies.Infrastructure;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;

using System.Web.Routing;

namespace Movies
{
	public class MvcApplication : System.Web.HttpApplication
	{
		private static IWindsorContainer _container;

		private static void BootstrapContainer()
		{
			_container = new WindsorContainer().Install(FromAssembly.This());

			var controllerFactory = new ControllerFactory(_container.Kernel);
			ControllerBuilder.Current.SetControllerFactory(controllerFactory);
		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AuthConfig.RegisterAuth();

			BootstrapContainer();
		}

		protected void Application_End()
		{
			_container.Dispose();
		}
	}

}