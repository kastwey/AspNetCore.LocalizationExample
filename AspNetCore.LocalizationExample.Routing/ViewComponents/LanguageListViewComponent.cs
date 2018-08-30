using AspNetCore.LocalizationExample.Routing.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.LocalizationExample.Routing.ViewComponents
{
	public class LanguageListViewComponent : ViewComponent
	{

		private readonly RequestLocalizationOptions _locOptions;

		public LanguageListViewComponent(RequestLocalizationOptions locOptions)
		{
			_locOptions = locOptions;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
			var cultureItems = _locOptions.SupportedUICultures.Select(c => new LanguageModel { Culture = c.Name, Name = c.NativeName, Active = CultureInfo.CurrentCulture.Name == c.Name });
			return View(cultureItems);
		}



	}
}
