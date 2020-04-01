using System;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.LocalizationExample.Models.Home;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace AspNetCore.LocalizationExample
{
	public class HomeController : Controller
	{
		private readonly IStringLocalizer<HomeController> _localizer;

		private readonly IStringLocalizer<SharedResources> _sharedLocalizer;

		public HomeController(IStringLocalizer<HomeController> localizer, IStringLocalizer<SharedResources> sharedLocalizer)
		{
			_localizer = localizer;
			_sharedLocalizer = sharedLocalizer;
		}

		public IActionResult Index()
		{
			var sharedText = _sharedLocalizer["Texto proveniente de Shared resources."];
			var controllerText = _localizer["Texto proveniente de HomeController resources."];

			return View();
		}


		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult SampleForm()
		{
			return View();
		}

		[HttpPost]
		public IActionResult SampleForm(SampleFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			return View("Registered");
		}

		public IActionResult SetLanguage(string culture, string returnUrl)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
			);

			return LocalRedirect(returnUrl);
		}

	}
}
