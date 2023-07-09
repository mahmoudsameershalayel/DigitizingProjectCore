using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.DistributorService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class DistributorController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IDistributorService _distributorService;
        public DistributorController(IDistributorService distributorService , ApplicationDbContext context)
        {
            _distributorService = distributorService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Distributors = await _distributorService.GetAll();
            ViewBag.db = _context;
            return View(_Distributors);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var _CreateUpdateProduct = await _distributorService.InjectCities();
            return View(_CreateUpdateProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateDistributorDto dto)
        {
            await _distributorService.Create(dto);
            return RedirectToAction("Index");
        }
    }
}
