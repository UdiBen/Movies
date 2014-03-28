using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Movies.Infrastructure
{
	public class GeneralInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly()
				.Where(type => type.Name.StartsWith("RavenDB"))
				.WithServiceDefaultInterfaces()
				.Configure(c => c.LifestyleTransient()));

			container.Register(
				AllTypes.FromThisAssembly()
					.Where(x => x.Namespace.StartsWith("RavenDB.Application"))
					.WithService.AllInterfaces());	
		
		}
	}
}