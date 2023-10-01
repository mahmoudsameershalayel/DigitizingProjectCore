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
        public async Task<IActionResult> Index()
        {
            var _JobsVM = await _jobService.GetAllForPublic();
            return View(_JobsVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var _JobsVM = await _jobService.GetVMById(id);
            return View(_JobsVM);
        }
    }
}
