using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index([FromServices]ApplicationDbContext _context)
        {
            ViewBag.db = _context;   
            return View();
        }
         
    }
}
