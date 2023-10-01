using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.ContactUsService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Send(CreateContactUsDto dto)
        {
            if (ModelState.IsValid) {
                await _contactUsService.Create(dto);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SendFromHome(CreateContactUsDto dto)
        {
            await _contactUsService.Create(dto);
            return View("Views/Home/Index.cshtml");
        }

    }
}
