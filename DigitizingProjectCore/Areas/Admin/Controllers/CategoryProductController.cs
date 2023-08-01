using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Services.CategoryProductService;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class CategoryProductController : AdminBaseController
    {
        private readonly ICategoryProductService _categoryProductService;
        public CategoryProductController(ICategoryProductService categoryProductService)
        {
            _categoryProductService = categoryProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] ApplicationDbContext _context, string? key, int pg = 1)
        {
            var _Categories = await _categoryProductService.GetAll(key);
            const int pageSize = 7;
            if (pg < 1)
            {
                pg = 1;
            }
            int _categoriesCount = _Categories.Count;
            var pager = new Pager(_categoriesCount, pg, pageSize);
            int _categorySkip = (pg - 1) * pageSize;
            var data = _Categories.Skip(_categorySkip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;
            ViewBag.db = _context;
            return View(data);
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
                await _categoryProductService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryProductService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _category = await _categoryProductService.GetById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryProductService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryProductService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _category = await _categoryProductService.GetById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateCategoryDto dto)
        {
            await _categoryProductService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryProductService.GetAll()) });
        }
    }
}
