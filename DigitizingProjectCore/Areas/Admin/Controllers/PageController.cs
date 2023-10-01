using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Services.CategoryProductService;
using DigitizingProjectCore.Services.PageService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class PageController : AdminBaseController
    {
        private readonly IPageService _pageService;
        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? key, bool? isActive)
        {
            var _Pages = await _pageService.GetAll(key, isActive);
            return View(_Pages);
        }

        [HttpGet]
        public IActionResult Add([FromServices] ApplicationDbContext _context)
        {
            ViewBag.db = _context;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromServices] ApplicationDbContext _context, CreateUpdatePageDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.db = _context;
                return View(dto);
            }
            await _pageService.Create(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit([FromServices] ApplicationDbContext _context,int id)
        {
            var _Page = await _pageService.GetById(id);
            ViewBag.db = _context;
            return View(_Page);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromServices] ApplicationDbContext _context,CreateUpdatePageDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.db = _context;
                return View(dto);
            }
            await _pageService.Update(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _Page = await _pageService.GetById(id);
            return View(_Page);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateCategoryDto dto)
        {
            await _pageService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _pageService.GetAll()) });
        }
    }
}
