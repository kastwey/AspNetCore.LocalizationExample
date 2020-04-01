using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.LocalizationExample.Routing
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
			var supportedCultures = new[] { "es-ES", "en-US" };
			var localizationOptions = new RequestLocalizationOptions();
			localizationOptions.AddSupportedCultures(supportedCultures)
				.AddSupportedUICultures(supportedCultures)
				.SetDefaultCulture(supportedCultures[0]);
			services.AddSingleton(localizationOptions);
			services.AddLocalization(opt => opt.ResourcesPath = "Resources");
			services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
				.AddDataAnnotationsLocalization();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, RequestLocalizationOptions options)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRequestLocalization(options);
			app.UseRouting();
			app.UseEndpoints(routeBuilder =>
			{
				routeBuilder.MapDefaultControllerRoute();
			});
		}
	}
}
