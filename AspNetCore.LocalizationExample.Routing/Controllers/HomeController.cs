using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCore.LocalizationExample.Routing.Models;
using System.Threading;
using System.Globalization;
using AspNetCore.LocalizationExample.Routing.Models.Home;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;

namespace AspNetCore.LocalizationExample.Routing.Controllers
{
	public class HomeController : Controller
	{

		private readonly IStringLocalizer<HomeController> _localizer;

		private readonly IStringLocalizer<SharedResources> _sharedLocalizer;

		public HomeController(IStringLocalizer<HomeController> localizer,  IStringLocalizer<SharedResources> sharedLocalizer)
		{
			_localizer = localizer;
			_sharedLocalizer = sharedLocalizer;
		}

		public IActionResult Index()
		{
			ViewData["sharedControllerText"] = _sharedLocalizer["Texto proveniente de Shared resources."];
			ViewData["controllerText"] = _localizer["Texto proveniente de HomeController resources."];
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

		public IActionResult Privacy()
		{
			return View();
		}

	}
}
