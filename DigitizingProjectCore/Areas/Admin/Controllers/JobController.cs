using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.CategoryNewsService;
using DigitizingProjectCore.Services.JobService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class JobController : AdminBaseController
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? key , bool? isActive)
        {
            var _Jobs = await _jobService.GetAll(key , isActive);
            return View(_Jobs);
        }
        [HttpGet]
        public IActionResult Add([FromServices] ApplicationDbContext _context)
        {
            ViewBag.db = _context;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromServices] ApplicationDbContext _context , CreateUpdateJobDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.db = _context;
                return View(dto);            
            }
            await _jobService.Create(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromServices] ApplicationDbContext _context,int id)
        {
            
            var _Job = await _jobService.GetById(id);
            ViewBag.db = _context;
            return View(_Job);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromServices] ApplicationDbContext _context , CreateUpdateJobDto dto)
        {
            if (ModelState.IsValid)
            {
                await _jobService.Update(dto);
                return RedirectToAction("Index");
            }
            ViewBag.db = _context;
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var _Job = await _jobService.GetById(id);
            return View(_Job);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(CreateUpdateJobDto dto)
        {
            await _jobService.Delete(dto.Id);
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", await _jobService.GetAll()) });
        }
    }
}
