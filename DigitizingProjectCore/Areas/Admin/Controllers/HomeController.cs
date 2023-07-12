using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.db = _context;   
            return View();
        }
         
    }
}
