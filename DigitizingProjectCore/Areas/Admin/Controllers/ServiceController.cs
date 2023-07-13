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
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ServiceController(IServiceService serviceService , ApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _ServiceService = serviceService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Services = await _ServiceService.GetAll();
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
                return RedirectToAction("Index");
            }
            return View();
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
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _ServiceService.Delete(id);
            return Json(new { id = id, message = "Deleted Successfully" });
        }
    }
}
