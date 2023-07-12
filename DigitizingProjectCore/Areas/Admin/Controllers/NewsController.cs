using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.CategoryNewsService;
using DigitizingProjectCore.Services.NewsService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class NewsController : AdminBaseController
    {
        private readonly INewsService _newsService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public NewsController(INewsService newsService, ApplicationDbContext context , IMapper mapper)
        {
            _newsService = newsService;
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _News = await _newsService.GetAll();
            ViewBag.db = _context;
            return View(_News);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var _CreateUpdateNews = await _newsService.InjectCategories();
            return View(_CreateUpdateNews);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateNewsDto dto)
        {
            if (ModelState.IsValid)
            {
                await _newsService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _newsService.GetAll()) });
            }
            var _CreateUpdateNews = await _newsService.InjectCategories();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", _CreateUpdateNews) });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _News = await _newsService.GetNewsById(id);
            var _AddNewsWithCategory = await _newsService.InjectCategories();
            _AddNewsWithCategory = _mapper.Map(_News, _AddNewsWithCategory);
            return View(_AddNewsWithCategory);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateNewsDto dto)
        {
            if (ModelState.IsValid)
            {
                await _newsService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _newsService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _category = await _newsService.GetDtoById(id);
            return View(_category);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateCategoryDto dto)
        {
            await _newsService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _newsService.GetAll()) });
        }
    }
}
