using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ServiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int CategoryId)
        {
            var service = _context.CategoryForServices.Where(x => x.IsDelete == false && x.IsActive == true && (x.Id == CategoryId)).OrderBy(x => x.SortId).FirstOrDefault();
            var item = _context.Services.Where(x => x.IsDelete == false && x.IsActive == true && x.CategoryId == CategoryId).FirstOrDefault();
            if (item == null)
            {
                throw new Exception("Not Found!!");
            }
            ViewBag.db = _context;
            return View(service);
        }
    }
}
