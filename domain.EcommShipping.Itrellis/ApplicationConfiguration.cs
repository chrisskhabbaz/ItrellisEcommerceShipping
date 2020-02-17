using System;
using System.Collections.Generic;
using System.Text;
using data.EcommShipping.Iitrellis.Context;
using domain.EcommShipping.Itrellis.Processors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace domain.EcommShipping.Itrellis
{
	public static class ApplicationConfiguration
	{
		public static void ConfigureInjectionContainer(IServiceCollection services)
		{
			services.AddScoped<IShippingCalculator, ShippingCalculator>();
			services.AddScoped<IRepository, Repository>();
			services.AddScoped<IBusinessProcessor, BusinessProcessor>();
		}
	}
}
