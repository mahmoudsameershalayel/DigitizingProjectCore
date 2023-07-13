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
            var _CreateUpdateDistributor = await _distributorService.InjectCities();
            return View(_CreateUpdateDistributor);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateDistributorDto dto)
        {
            if (ModelState.IsValid)
            {
                await _distributorService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _distributorService.GetAll()) });
            }

            var _CreateUpdateDistributor = await _distributorService.InjectCities();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", _CreateUpdateDistributor) });
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
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _distributorService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _Distributor = await _distributorService.GetById(id);
            var dto = _mapper.Map<CreateUpdateDistributorDto>(_Distributor);
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateDistributorDto dto)
        {
            await _distributorService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _distributorService.GetAll()) });
        }
    }
}
