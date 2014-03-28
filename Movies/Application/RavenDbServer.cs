using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace Movies.Application
{
	public interface IRavenDbServer
	{
		IDocumentSession OpenSession();
	}

	public class RavenDbServer : IRavenDbServer
	{
		private readonly DocumentStore _documentStore;

		public RavenDbServer()
		{
			_documentStore = new DocumentStore { Url = @"http://localhost:8080/" };
			_documentStore.Initialize();
		}

		public IDocumentSession OpenSession()
		{
			return _documentStore.OpenSession("Movies");
		}
	}
}