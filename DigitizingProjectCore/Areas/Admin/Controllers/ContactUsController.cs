using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.AboutUsService;
using DigitizingProjectCore.Services.ContactUsService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class ContactUsController : AdminBaseController
    {
        private readonly ApplicationDbContext _context;
        private readonly IContactUsService _contactUsService;
        public ContactUsController(ApplicationDbContext context, IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? key)
        {
            var contactUs = await _contactUsService.GetAll(key);
            ViewBag.db = _context;
            return View(contactUs);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var contactUs = await _contactUsService.GetById(id);
            ViewBag.db = _context;
            return View(contactUs);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var contactUs = await _contactUsService.GetById(id);
            return View(contactUs);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateCategoryDto dto)
        {
            await _contactUsService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _contactUsService.GetAll()) });
        }
        [HttpPost]
        public async Task<IActionResult> EditReaded(int id , bool isReaded)
        {
            await _contactUsService.EditReaded(id , isReaded);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _contactUsService.GetAll()) });
        }
    }
}
