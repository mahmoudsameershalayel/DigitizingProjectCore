using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.CityService;
using Humanizer.Localisation;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class CityController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(ICityService cityService, IMapper mapper , ApplicationDbContext context)
        {
            _cityService = cityService;
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Cities = await _cityService.GetAll();
            ViewBag.db = _context;
            return View(_Cities);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CityViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _cityService.Create(vm);
            }
            return new JsonResult(Ok()); 
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _City = await _cityService.GetById(id);
            var _CityVM = _mapper.Map<CityViewModel>(_City);
            return View(_CityVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CityViewModel vm)
        {
            if (ModelState.IsValid)
            {
                await _cityService.Update(vm);
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _cityService.Delete(id);
            return Json(new { id = id, message = "Deleted Successfully" });
        }
    }
}
