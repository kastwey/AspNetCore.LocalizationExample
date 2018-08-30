using System;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.LocalizationExample.Models.Home;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.LocalizationExample
{
	public class HomeController : Controller
	{

		public IActionResult Index()
		{
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
