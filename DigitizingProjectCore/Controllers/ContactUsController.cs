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
        public IActionResult Index([FromServices] ApplicationDbContext _context)
        {
            ViewBag.db = _context;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Send([FromServices] ApplicationDbContext _context , CreateContactUsDto dto)
        {
            if (ModelState.IsValid) {
                await _contactUsService.Create(dto);
                return RedirectToAction("Index");
            }
            ViewBag.db = _context;
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> SendFromHome([FromServices] ApplicationDbContext _context , CreateContactUsDto dto)
        {
            await _contactUsService.Create(dto);
            ViewBag.db = _context;
            return View("Views/Home/Index.cshtml");
        }

    }
}
