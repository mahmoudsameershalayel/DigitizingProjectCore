using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.JobApplicationService
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public JobApplicationService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<JobApplicationViewModel>> GetAll()
        {
            var _JobApplications = await _context.jobApplications.Where(x => x.IsDelete == false).OrderBy(x => x.SortId).Include(x => x.Job).ToListAsync();
            var _JobApplicationsVM = _mapper.Map<List<JobApplicationViewModel>>(_JobApplications);
            return _JobApplicationsVM;
        }
        public async Task<List<JobApplicationViewModel>> GetAll(string? key, int? jobId, bool? isChecked, bool? haveLiscence, bool? stillWork)
        {
            var _JobApplications = await _context.jobApplications.Where(x => x.IsDelete == false && (string.IsNullOrEmpty(key) || x.Name.Contains(key)) && (isChecked == null || isChecked == x.IsChecked) && (haveLiscence == null || haveLiscence == x.HaveDrivingLiscence) && (stillWork == null || stillWork == x.StillWork)).OrderBy(x => x.SortId).Include(x => x.Job).ToListAsync();
            var _JobApplicationsVM = _mapper.Map<List<JobApplicationViewModel>>(_JobApplications);
            return _JobApplicationsVM;
        }

        public Task<CreateJobApplicationDto> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<CreateJobApplicationDto> Create(CreateJobApplicationDto dto)
        {
            var _JobApplication = _mapper.Map<JobApplication>(dto);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _JobApplication.Created_By = _UserId;
            _JobApplication.Created_At = DateTime.Now;
            _JobApplication.IsDelete = false;
            await _context.jobApplications.AddAsync(_JobApplication);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateJobApplicationDto> InjectJMD(int id)
        {
            var _Job = await _context.Jobs.Where(x => x.IsDelete == false && x.IsActive == true && x.Id == id).FirstOrDefaultAsync();
            var _Jobs = await _context.Jobs.Where(x => x.IsDelete == false).ToListAsync();
            var _MartialStatus = await _context.MaritalStatus.ToListAsync();
            var _DrivingLiscenceTypes = await _context.DrivingLiscenceTypes.ToListAsync();
            var dto = new AddJobApplicationWithJMD();
            dto.Job = _Job;
            dto.InjectJobsEn(_Jobs);    
            dto.InjectJobsAr(_Jobs);
            dto.InjectMaritalStatusEn(_MartialStatus);
            dto.InjectMaritalStatusAr(_MartialStatus);
            dto.InjectDrivingLiscenceEn(_DrivingLiscenceTypes);
            dto.InjectDrivingLiscenceAr(_DrivingLiscenceTypes);
            return dto;
        }

        
    }
}
