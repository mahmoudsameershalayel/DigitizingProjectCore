using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.AboutUsService;
using DigitizingProjectCore.Services.ConfigurationService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class AboutUsController : AdminBaseController
    {
        private readonly IAboutUsService _aboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            return View(await _aboutUsService.Get());
        }
        [HttpPost]
        public async Task<IActionResult> Save(SaveAboutUsDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Not Valid!!");
            }
            var _AboutUsDto = await _aboutUsService.Save(dto);
            return View(_AboutUsDto);
        }
    }
}
