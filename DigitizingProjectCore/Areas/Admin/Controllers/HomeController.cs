using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Links()
        {
            return View();
        }
    }
}
