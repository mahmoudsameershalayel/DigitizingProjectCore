using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.AboutUsService;
using DigitizingProjectCore.Services.SettingService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class SettingController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly ISettingService _settingService;
        public SettingController(ApplicationDbContext context, ISettingService settingService)
        {
            _settingService = settingService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            ViewBag.db = _context;
            return View(await _settingService.Get());
        }
        [HttpPost]
        public async Task<IActionResult> Save(SaveSettingDto dto)
        {
            if (ModelState.IsValid)
            {
                await _settingService.Save(dto);
            }
            ViewBag.db = _context;
            return View(dto);
        }
    }
}
