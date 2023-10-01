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
        private readonly ISolutionService _solutionService;
        private readonly IMapper _mapper;

        public SolutionController(ISolutionService solutionService, IMapper mapper)
        {
            _solutionService = solutionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? key)
        {
            var _Solutions = await _solutionService.GetAll(key);
            return View(_Solutions);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var _CreateUpdateSolution = await _solutionService.InjectCategoriesAndBrandsAndProducts();
            ViewBag.Products = _solutionService.GetAllProducts();
            return View(_CreateUpdateSolution);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateSolutionDto dto)
        {
            if (!ModelState.IsValid)
            {
                var _CreateUpdateSolution = await _solutionService.InjectCategoriesAndBrandsAndProducts();
                return View(_CreateUpdateSolution);
            }
            await _solutionService.Create(dto);
            return RedirectToAction("Index");
            }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _Solution = await _solutionService.GetById(id);
            var _AddSolutionWithCBP = await _solutionService.InjectCategoriesAndBrandsAndProducts();
            _AddSolutionWithCBP = _mapper.Map(_Solution, _AddSolutionWithCBP);
            return View(_AddSolutionWithCBP);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateSolutionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _solutionService.Update(dto);
            return RedirectToAction(nameof(Index));
            
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _Solution = await _solutionService.GetById(id);
            return View(_Solution);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Solution item)
        {
            await _solutionService.Delete(item.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _solutionService.GetAll()) });
        }
    }
}
