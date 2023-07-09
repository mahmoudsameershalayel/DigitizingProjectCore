using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Controllers
{
    public class ProductController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Products = await _context.Products.Include(x => x.Category).Include(x => x.Brand).ToListAsync();
            return View(_Products);
        }
    }
}
