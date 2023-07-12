using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
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
        public async Task<IActionResult> Index(string key, int? categoryId, int? solutionId, int? brandId)
        {
            var _Products = await _context.Products.Where(x => x.IsDelete == false && x.IsActive == true && (key == null || x.NameAr.Contains(key) && x.NameEn.Contains(key)) && (categoryId == null || x.CategoryId == categoryId) && (solutionId == null || x.SolutionProducts.Count(y => y.SolutionId == solutionId) > 0) && (brandId == null || x.BrandId == brandId)).OrderBy(x => x.SortId).Include(x => x.Category).Include(x => x.Brand).ToListAsync();
            ViewBag.db = _context;
            return View(_Products);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var _Product = await _context.Products.Where(x => x.Id == id).Include(x => x.Category).Include(x => x.Brand).FirstOrDefaultAsync();
            if (_Product == null)
            {
                throw new Exception("Not Found!!");
            }
            ViewBag.db = _context;
            return View(_Product);
        }

    }
}
