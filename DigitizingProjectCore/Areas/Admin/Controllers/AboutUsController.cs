using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.AboutUsService;
using DigitizingProjectCore.Services.ConfigurationService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class AboutUsController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IAboutUsService _aboutUsService;
        public AboutUsController(ApplicationDbContext context, IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            ViewBag.db = _context;
            return View(await _aboutUsService.Get());
        }
        [HttpPost]
        public async Task<IActionResult> Save(SaveAboutUsDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Not Valid!!");
            }
            ViewBag.db = _context;
            var _AboutUsDto = await _aboutUsService.Save(dto);
            return View(_AboutUsDto);
        }
    }
}
