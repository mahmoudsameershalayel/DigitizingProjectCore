using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.CategoryProductService;
using DigitizingProjectCore.Services.ConfigurationService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class ConfigurationController : AdminBaseController
    {
        private readonly IConfigurationService _configurationService;
        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            return View(await _configurationService.Get());
        }
        [HttpPost]
        public async Task<IActionResult> Save(SaveConfigurationDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Not Valid!!");
            }
            var _ConfigDto = await _configurationService.Save(dto);
            return View(_ConfigDto);
        }
    }
}
