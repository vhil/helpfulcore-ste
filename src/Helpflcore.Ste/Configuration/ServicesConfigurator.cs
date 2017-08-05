namespace Helpflcore.Ste.Configuration
{
	using Microsoft.Extensions.DependencyInjection;
	using Sitecore.DependencyInjection;
	using Model;

	public class ServicesConfigurator : IServicesConfigurator
	{
		public void Configure(IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton(typeof(IStronglyTypedFieldFactory), provider => StronglyTypedFieldFactory.FromConfiguration());
		}
	}
}
