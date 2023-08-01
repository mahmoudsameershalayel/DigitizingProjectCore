using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.CategoryNewsService;
using DigitizingProjectCore.Services.CategoryServiceService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class CategoryNewsController : AdminBaseController
    {
        private readonly ICategoryNewsService _categoryNewsService;
        public CategoryNewsController(ICategoryNewsService categoryNewsService)
        {
            _categoryNewsService = categoryNewsService;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromServices]ApplicationDbContext _context , string? key)
        {
            var _Categories = await _categoryNewsService.GetAll(key);
            ViewBag.db = _context;
            return View(_Categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryNewsService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryNewsService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _category = await _categoryNewsService.GetById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryNewsService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryNewsService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _category = await _categoryNewsService.GetById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateCategoryDto dto)
        {
            await _categoryNewsService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryNewsService.GetAll()) });
        }
    }
}
