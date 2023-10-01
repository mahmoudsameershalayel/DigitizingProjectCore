using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Controllers
{
    public class DistributorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DistributorController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var distributors = await _context.Distributors.Where(x => x.IsDelete == false && x.IsActive == true).Include(x => x.City).ToListAsync();
            return View(distributors);
        }
    }
}
