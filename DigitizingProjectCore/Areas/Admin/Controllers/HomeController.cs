using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        public IActionResult GetAllLinks() { 
            var data = _context.Links.ToList();
            return Json(data);
        }
        public IActionResult GetSubLinks(int id)
        {
            var data = _context.Links.Where(x => x.ParentId == id).OrderBy(x => x.OrderId).ToList();
            return Json(data);
        }
    }
}
