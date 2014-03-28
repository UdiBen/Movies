using Movies.Application;
using Movies.Infrastructure;
using System.Web.Mvc;

namespace Movies.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRavenDbServer _ravenDbServer;

		public HomeController(IRavenDbServer ravenDbServer)
		{
			_ravenDbServer = ravenDbServer;
		}

		[PatternRoute("")]
		public ActionResult Index()
		{
			ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

			using (var session = _ravenDbServer.OpenSession())
			{
				var data = new MyData
				{
					Id = 1,
					Name = "Udi"
				};
				session.Store(data);
				session.SaveChanges();
			}

			return View();
		}

		[PatternRoute("movies")]
		public ActionResult Movies()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}
	}

	public class MyData
	{
		public long Id { get; set; }
		public string Name { get; set; }
	}
}
