using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Controllers
{
    public class SolutionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SolutionController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string key, int? categoryId , int? brandId)
        {
            var _Solution = await _context.Solutions.Where(x => x.IsDelete == false && x.IsActive == true && (string.IsNullOrEmpty(key) || x.NameAr.Contains(key) && x.NameEN.Contains(key)) && (categoryId == null || x.CategoryId == categoryId)  && (brandId == null || x.BrandId == brandId)).Include(x => x.Category).Include(x => x.Brand).OrderBy(x => x.SortId).ToListAsync();
            return View(_Solution);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var _Solution = await _context.Solutions.Where(x => x.Id == id).Include(x => x.Category).Include(x => x.Brand).FirstOrDefaultAsync();
            if (_Solution == null)
            {
                throw new Exception("Not Found!!");
            }
            return View(_Solution);
        }
    }
}
