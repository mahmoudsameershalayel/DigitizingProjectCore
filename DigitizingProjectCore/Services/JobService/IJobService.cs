using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.JobService
{
    public interface IJobService
    {
        public Task<List<JobViewModel>> GetAll();
        public Task<List<JobViewModel>> GetAll(string? key, bool? isActive);
        public Task<List<JobViewModel>> GetAllForPublic();
        public Task<CreateUpdateJobDto> GetById(int id);
        public Task<JobViewModel> GetVMById(int id);
        public Task<CreateUpdateJobDto> Create(CreateUpdateJobDto dto);
        public Task<CreateUpdateJobDto> Update(CreateUpdateJobDto dto);
        public Task<int> Delete(int id);
    }
}
