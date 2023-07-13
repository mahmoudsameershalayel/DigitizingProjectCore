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
            if (ModelState.IsValid)
            {
                await _BrandService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _BrandService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });

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
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _BrandService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _Brand = await _BrandService.GetById(id);
            var dto = _mapper.Map<CreateUpdateBrandDto>(_Brand);
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateCategoryDto dto)
        {
            await _BrandService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _BrandService.GetAll()) });
        }
    }
}
