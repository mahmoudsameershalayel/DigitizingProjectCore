using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Services.ProductService;
using DigitizingProjectCore.Services.SolutionService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class SolutionController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ISolutionService _solutionService;
        private readonly IMapper _mapper;

        public SolutionController(ISolutionService solutionService, IMapper mapper, ApplicationDbContext context)
        {
            _solutionService = solutionService;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Solutions = await _solutionService.GetAll();
            ViewBag.db = _context;
            return View(_Solutions);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var _CreateUpdateSolution = await _solutionService.InjectCategoriesAndBrandsAndProducts();
            ViewBag.db = _context;
            return View(_CreateUpdateSolution);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateSolutionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _solutionService.Create(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _Solution = await _solutionService.GetById(id);
            var _AddSolutionWithCategoryAndBrandAndProduct = await _solutionService.InjectCategoriesAndBrandsAndProducts();
            _AddSolutionWithCategoryAndBrandAndProduct = _mapper.Map(_Solution, _AddSolutionWithCategoryAndBrandAndProduct);
            return View(_AddSolutionWithCategoryAndBrandAndProduct);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateSolutionDto dto)
        {
            if (ModelState.IsValid)
            {
                await _solutionService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _solutionService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, int y)
        {
            await _solutionService.Delete(id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _solutionService.GetAll()) });
        }
    }
}
