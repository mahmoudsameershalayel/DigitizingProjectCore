using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Controllers
{
    public class CultureController : Controller
    {
        public IActionResult SetCulture(string culture)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) }
            );

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
