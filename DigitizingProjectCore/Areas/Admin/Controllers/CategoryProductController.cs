using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Services.CategoryProductService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class CategoryProductController : AdminBaseController
    {
        private readonly ICategoryProductService _categoryProductService;
        private readonly IMapper _mapper;
        public CategoryProductController(ICategoryProductService categoryProductService,IMapper mapper)
        {
            _categoryProductService = categoryProductService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int pg = 1)
        {
            var _Categories = await _categoryProductService.GetAll();
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
            return View(data);
        }

        [HttpGet]
        public IActionResult Add() {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateCategoryDto dto) {
            if (ModelState.IsValid) { 
                await _categoryProductService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAllProductCategory", _categoryProductService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", _categoryProductService.GetById(dto.Id)) });
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _category = await _categoryProductService.GetById(id);
            var _CreateUpdateCategory = _mapper.Map<CreateUpdateCategoryDto>(_category);
            return View(_CreateUpdateCategory);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryProductService.Update(dto);
            }   
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id) { 
            await _categoryProductService.Delete(id);
            return Json(new { id = id, message = "Deleted Successfully" });
        }
    } 
}
