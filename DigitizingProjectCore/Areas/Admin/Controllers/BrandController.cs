using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.BrandServices;
using DigitizingProjectCore.Services.CategoryProductService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class BrandController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IBrandService _BrandService;
        private readonly IMapper _mapper;
        public BrandController(IBrandService BrandService, IMapper mapper , ApplicationDbContext context)
        {
            _BrandService = BrandService;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Brands = await _BrandService.GetAll();
            ViewBag.db = _context;
            return View(_Brands);
        }
        [HttpGet]
        public async Task<IActionResult> GetByName(string key)
        {
            var _brands = await _BrandService.GetByName(key);
            return PartialView("_SearchBrandsResultsPartial", _brands);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateBrandDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _BrandService.Create(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _Brand = await _BrandService.GetById(id);
            var _CreateUpdateBrandDto = _mapper.Map<CreateUpdateBrandDto>(_Brand);
            return View(_CreateUpdateBrandDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateBrandDto dto)
        {
            if (ModelState.IsValid)
            {
                await _BrandService.Update(dto);
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _BrandService.Delete(id);
            return Json(new { id = id, message = "Deleted Successfully" });
        }
    }
}
