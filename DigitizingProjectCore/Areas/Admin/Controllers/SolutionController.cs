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
        public async Task<IActionResult> Index([FromServices] ApplicationDbContext _context)
        {
            var _Solutions = await _solutionService.GetAll();
            ViewBag.db = _context;
            return View(_Solutions);
        }
        [HttpGet]
        public async Task<IActionResult> Add([FromServices] ApplicationDbContext _context)
        {
            var _CreateUpdateSolution = await _solutionService.InjectCategoriesAndBrandsAndProducts();
            ViewBag.db = _context;
            ViewBag.Products = _solutionService.GetAllProducts();
            return View(_CreateUpdateSolution);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromServices] ApplicationDbContext _context,CreateUpdateSolutionDto dto)
        {
            if (!ModelState.IsValid)
            {
                var _CreateUpdateSolution = await _solutionService.InjectCategoriesAndBrandsAndProducts();
                ViewBag.db = _context;
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
