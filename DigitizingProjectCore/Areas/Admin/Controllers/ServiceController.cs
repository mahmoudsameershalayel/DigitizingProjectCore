using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using DigitizingProjectCore.Services.ServiceService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class ServiceController : AdminBaseController
    {
        private readonly IServiceService _ServiceService;
        private readonly IMapper _mapper;
        public ServiceController(IServiceService serviceService , IMapper mapper)
        {
            _mapper = mapper;
            _ServiceService = serviceService;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] ApplicationDbContext _context , string? key , int? categoryId , bool? isActive)
        {
            var _Services = await _ServiceService.GetAll(key , categoryId , isActive);
            ViewBag.db = _context;
            return View(_Services);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var _CreateUpdateService = await _ServiceService.InjectCategories();
            return View(_CreateUpdateService);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateServiceDto dto)
        {
            if (ModelState.IsValid)
            {
                await _ServiceService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _ServiceService.GetAll()) });
            }
            var _CreateUpdateService = await _ServiceService.InjectCategories();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", _CreateUpdateService) });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _Service = await _ServiceService.GetServiceById(id);
            var _AddServiceWithCategory = await _ServiceService.InjectCategories();
            _AddServiceWithCategory = _mapper.Map(_Service, _AddServiceWithCategory);
            return View(_AddServiceWithCategory);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateServiceDto dto)
        {
            if (ModelState.IsValid)
            {
                await _ServiceService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _ServiceService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _Service = await _ServiceService.GetServiceById(id);
            var dto = _mapper.Map<CreateUpdateServiceDto>(_Service);
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateProductDto dto)
        {
            await _ServiceService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _ServiceService.GetAll()) });
        }
    }
}
