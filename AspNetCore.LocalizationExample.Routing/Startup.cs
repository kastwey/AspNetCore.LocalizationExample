﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.LocalizationExample.Routing.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization.Routing;
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
				.SetDefaultCulture(supportedCultures[0])
				.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider() { Options = localizationOptions });
			services.AddSingleton(localizationOptions);
			services.AddLocalization(opt => opt.ResourcesPath = "Resources");
			services.AddControllersWithViews(mvcOptions =>
			{
				mvcOptions.Filters.Add(typeof(CultureRedirectFilter));
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
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
			app.UseRouting();
			app.UseRequestLocalization(options);
			app.UseEndpoints(routeBuilder =>
			{
				routeBuilder.MapControllerRoute(
					name: "default",
					pattern: "{culture:regex(^[a-z]{{2}}(\\-[A-Z]{{2}})?$)}/{controller=Home}/{action=Index}/{id?}"
					);
				routeBuilder.MapControllerRoute(
					name: "defaultWithoutLanguage",
					pattern: "{controller=Home}/{action=Index}/{id?}"
					);
			});
		}
	}
}
