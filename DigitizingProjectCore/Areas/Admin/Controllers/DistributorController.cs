using AutoMapper;
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
        private readonly IMapper _mapper;
        public DistributorController(IDistributorService distributorService , ApplicationDbContext context , IMapper mapper)
        {
            _distributorService = distributorService;
            _mapper = mapper;
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _Distributor = await _distributorService.GetById(id);
            var _AddDistributorWithCity = await _distributorService.InjectCities();
            _AddDistributorWithCity = _mapper.Map(_Distributor, _AddDistributorWithCity);
            return View(_AddDistributorWithCity);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateDistributorDto dto)
        {
            if (ModelState.IsValid)
            {
                await _distributorService.Update(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _distributorService.Delete(id);
            return Json(new { id = id, message = "Deleted Successfully" });
        }
    }
}
