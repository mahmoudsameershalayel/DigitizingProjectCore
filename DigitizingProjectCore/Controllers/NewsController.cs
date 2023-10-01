using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _News = await _context.News.Where(x => x.IsDelete == false && x.IsActive == true).Include(x => x.Category).ToListAsync();
            return View(_News);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var _News = await _context.News.Where(x => x.IsDelete == false && x.IsActive == true && x.Id == id).Include(x => x.Category).FirstOrDefaultAsync();
            return View(_News);
        }
    }
}
