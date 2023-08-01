using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.JobService
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public JobService(ApplicationDbContext context, IMapper mapper,  IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }
        public async Task<List<JobViewModel>> GetAll()
        {
            var _Jobs = await _context.Jobs.Where(x => x.IsDelete == false).OrderBy(x => x.SortId).ToListAsync();
            var _JobsVM = _mapper.Map<List<JobViewModel>>(_Jobs);
            return _JobsVM;
        }
        public async Task<List<JobViewModel>> GetAll(string? key, bool? isActive)
        {
            var _Jobs = await _context.Jobs.Where(x => x.IsDelete == false && (string.IsNullOrEmpty(key) || x.JobTitleEn.Contains(key) || x.JobTitleAr.Contains(key)) && (isActive == null || isActive == x.IsActive)).OrderBy(x => x.SortId).ToListAsync();
            var _JobsVM = _mapper.Map<List<JobViewModel>>(_Jobs);
            return _JobsVM;
        }
        public async Task<List<JobViewModel>> GetAllForPublic()
        {
            var _Jobs = await _context.Jobs.Where(x => x.IsDelete == false && x.IsActive == true && x.FromDate <= DateTime.Now && x.ToDate >= DateTime.Now).ToListAsync();
            var _JobsVM = _mapper.Map<List<JobViewModel>>(_Jobs);
            return _JobsVM;
        }
        
        public async Task<CreateUpdateJobDto> GetById(int id)
        {
            var _Job = await _context.Jobs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Job != null)
            {
                var dto = _mapper.Map<CreateUpdateJobDto>(_Job);
                return dto;
            }
            return null;
           
        }
        public async Task<JobViewModel> GetVMById(int id)
        {
            var _Job = await _context.Jobs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Job != null)
            {
                var dto = _mapper.Map<JobViewModel>(_Job);
                return dto;
            }
            return null;
        }
        public async Task<CreateUpdateJobDto> Create(CreateUpdateJobDto dto)
        {
            var _Job = _mapper.Map<Job>(dto);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Job.Created_By = _UserId;
            _Job.Created_At = DateTime.Now;
            _Job.IsDelete = false;
            await _context.Jobs.AddAsync(_Job);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateJobDto> Update(CreateUpdateJobDto dto)
        {
            var _Job = await _context.Jobs.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Job != null)
            {
                var _UpdateJob = _mapper.Map(dto, _Job);
                var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
                _UpdateJob.Updated_By = _UserId;
                _UpdateJob.Updated_At = DateTime.Now;
                _context.Jobs.Update(_Job);
                await _context.SaveChangesAsync();
            }
            return dto;
        }
        public async Task<int> Delete(int id)
        {
            var _Job = await _context.Jobs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Job != null)
            {
                _Job.IsDelete = true;
                _context.Jobs.Update(_Job);
            }
            return await _context.SaveChangesAsync();
        }

        
    }
}
