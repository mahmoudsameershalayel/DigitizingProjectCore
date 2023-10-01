using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.AboutUsService;
using DigitizingProjectCore.Services.SettingService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class SettingController : AdminBaseController
    {
        private readonly ISettingService _settingService;
        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            return View(await _settingService.Get());
        }
        [HttpPost]
        public async Task<IActionResult> Save(SaveSettingDto dto)
        {
            if (ModelState.IsValid)
            {
                await _settingService.Save(dto);
            }
            return View(dto);
        }
    }
}
