using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.JobService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] ApplicationDbContext _context)
        {
            var _JobsVM = await _jobService.GetAllForPublic();
            ViewBag.db = _context;
            return View(_JobsVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details([FromServices] ApplicationDbContext _context, int id)
        {
            var _JobsVM = await _jobService.GetVMById(id);
            ViewBag.db = _context;
            return View(_JobsVM);
        }
    }
}
