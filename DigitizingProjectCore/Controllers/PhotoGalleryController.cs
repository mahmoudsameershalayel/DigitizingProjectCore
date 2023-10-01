using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Controllers
{
    public class PhotoGalleryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PhotoGalleryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var newsQuery = await _context.PhotoGalleries.Where(x => x.IsDelete == false && x.IsActive == true).OrderByDescending(x => x.Created_At).ToListAsync();
            return View(newsQuery);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var newsQuery = await _context.PhotoGalleries.Where(x => x.IsDelete == false && x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
            return View(newsQuery);
        }
    }
}
