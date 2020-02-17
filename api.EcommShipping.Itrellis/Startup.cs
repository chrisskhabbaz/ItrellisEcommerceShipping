using System.IO;
using System.Reflection;
using api.EcommShipping.Itrellis.JsonSettings;
using data.EcommShipping.Iitrellis.Context;
using domain.EcommShipping.Itrellis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace api.EcommShipping.Itrellis
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			services.AddCors();
			services.AddOptions();
			services.AddMvc()
							.AddJsonOptions(opt =>
							{
								opt.SerializerSettings.Converters.Add(new StringTrimmingConverter());
								opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
							});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Version = "V1",
					Title = "Itrellis Ecommerce Service API",
					Description = "API for Shipping and Ecommerce Products information"
				});

				c.IncludeXmlComments(XmlCommentsFilePath);
			});
			//CALL STATIC METHOD FOR DEPENDENCY INJECTION SETUP
			ApplicationConfiguration.ConfigureInjectionContainer(services);
			services.AddDbContext<EcommerceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseSwagger();
			app.UseSwaggerUI(
			c =>
			{
				c.SwaggerEndpoint("/swagger/V1/swagger.json", "Itrellis Ecommerce Service API");
			});
			app.UseHttpsRedirection();
			app.UseMvc();
		}
		static string XmlCommentsFilePath
		{
			get
			{
				string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				var fileName = "EcommShippingService.xml";
				return Path.Combine(basePath, fileName);
			}
		}
	}
}
