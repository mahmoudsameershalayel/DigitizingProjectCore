using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Services.BrandService;
using DigitizingProjectCore.Services.CategoryProductService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class BrandController : AdminBaseController
    {
        private readonly IBrandService _BrandService;
        public BrandController(IBrandService BrandService)
        {
            _BrandService = BrandService;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] ApplicationDbContext _context, string? key)
        {
            var _Brands = await _BrandService.GetAll(key);
            ViewBag.db = _context;
            return View(_Brands);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string? key)
        {
            var items = await _BrandService.GetAll(key);
            var result =
               new
               {
                   data = items.ToList()
               };
            return Json(result);    
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
            return View(_Brand);
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
            return View(_Brand);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateCategoryDto dto)
        {
            await _BrandService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _BrandService.GetAll()) });
        }
    }
}
