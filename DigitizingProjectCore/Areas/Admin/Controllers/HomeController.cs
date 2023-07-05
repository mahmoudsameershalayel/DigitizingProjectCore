using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
