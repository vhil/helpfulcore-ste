﻿using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;

namespace Helpfulcore.Ste.Mvc.Configuration
{
	public class ServicesConfigurator : IServicesConfigurator
	{
		public void Configure(IServiceCollection serviceCollection)
		{
			serviceCollection.AddSingleton(provider => ViewModelFactory.Instance());
		}
	}
}
