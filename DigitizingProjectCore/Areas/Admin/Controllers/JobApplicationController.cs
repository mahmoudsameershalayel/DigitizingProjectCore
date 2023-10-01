using DigitizingProjectCore.Data;
using DigitizingProjectCore.Services.JobApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace DigitizingProjectCore.Areas.Admin.Controllers
{
    public class JobApplicationController : AdminBaseController
    {
        private readonly IJobApplicationService _jobApplicationService;
        public JobApplicationController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? key , int? jobId , bool? isChecked , bool? haveLiscence , bool? stillWork)
        {
            var _JobApplications = await _jobApplicationService.GetAll(key , jobId , isChecked , haveLiscence , stillWork);
            return View(_JobApplications);
        }
    }
}
