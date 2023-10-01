using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.CityService;
using DigitizingProjectCore.Services.HomeBageService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class HomePageBannerController : AdminBaseController
    {
        private readonly IHomePageService _homePageService;

        public HomePageBannerController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _Banners = await _homePageService.GetAll();
            return View(_Banners);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateUpdateHomePageDto dto)
        {
            if (ModelState.IsValid)
            {
                await _homePageService.Create(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _homePageService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Add", dto) });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var _Banner = await _homePageService.GetById(id);
            return View(_Banner);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateUpdateHomePageDto dto)
        {
            if (ModelState.IsValid)
            {
                await _homePageService.Update(dto);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await _homePageService.GetAll()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", dto) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _Banner = await _homePageService.GetById(id);
            return View(_Banner);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateHomePageDto dto)
        {
            await _homePageService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _homePageService.GetAll()) });
        }
    }
}
