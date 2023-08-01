using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.JobApplicationService
{
    public interface IJobApplicationService
    {
        public Task<List<JobApplicationViewModel>> GetAll();
        public Task<List<JobApplicationViewModel>> GetAll(string? key, int? jobId, bool? isChecked, bool? haveLiscence , bool? stillWork);
        public Task<CreateJobApplicationDto> GetById(int id);
        public Task<CreateJobApplicationDto> Create(CreateJobApplicationDto dto);
        public Task<CreateJobApplicationDto> InjectJMD(int id);
    }
}
