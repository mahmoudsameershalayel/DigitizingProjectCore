using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.JobApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly IJobApplicationService _jobApplicationService;
        public JobApplicationController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var _CreateUpdateJob = await _jobApplicationService.InjectJMD(id);
            return View(_CreateUpdateJob);
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateJobApplicationDto dto)
        {
            await _jobApplicationService.Create(dto);
            return View("Add");
        }
    }
}
