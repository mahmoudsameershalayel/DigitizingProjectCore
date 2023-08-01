using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;

namespace DigitizingProjectCore.Services.PageService
{
    public interface IPageService
    {
        public Task<List<PageViewModel>> GetAll();
        public Task<List<PageViewModel>> GetAll(string? key , bool? isActive);
        public Task<CreateUpdatePageDto> GetById(int id);
        public Task<CreateUpdatePageDto> Create(CreateUpdatePageDto dto);
        public Task<CreateUpdatePageDto> Update(CreateUpdatePageDto dto);
        public Task<int> Delete(int id);
    }
}
