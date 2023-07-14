using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.CityService;
using Humanizer.Localisation;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class CityController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICityService _cityService;

        public CityController(ICityService cityService , ApplicationDbContext context)
        {
            _cityService = cityService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Categories = await _cityService.GetAll();
            ViewBag.db = _context;
            return View(_Categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CityViewModel dto)
        {
            if (ModelState.IsValid)
            {
                await _cityService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _cityService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _category = await _cityService.GetById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CityViewModel dto)
        {
            if (ModelState.IsValid)
            {
                await _cityService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _cityService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _category = await _cityService.GetById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CityViewModel dto)
        {
            await _cityService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _cityService.GetAll()) });
        }
    }
}
