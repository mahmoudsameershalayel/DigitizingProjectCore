using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.CategoryServiceService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Drawing.Printing;
using System.Globalization;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class CategoryServiceController : AdminBaseController
    {
        private readonly ICategoryServiceService  _categoryServiceService;
        private readonly ApplicationDbContext _context;
       
        public CategoryServiceController(ICategoryServiceService categoryServiceService , ApplicationDbContext context)
        {
            _categoryServiceService = categoryServiceService;
            _context = context;
           
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Categories = await _categoryServiceService.GetAll();
            ViewBag.db = _context;
            return View(_Categories);
        }
        [HttpPost]
        public async Task<ActionResult> Search(string term = "")
        {
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryServiceService.Search(term)) });
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
                await  _categoryServiceService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryServiceService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _category = await _categoryServiceService.GetById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryServiceService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryServiceService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) {
            var _category = await _categoryServiceService.GetById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateCategoryDto dto)
        {
            await _categoryServiceService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _categoryServiceService.GetAll()) });
        }
        
    }
}
