using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;

namespace DigitizingProjectCore.Services.HomeBageService
{
    public interface IHomePageService
    {
        public Task<List<HomePageViewModel>> GetAll();
        public Task<CreateUpdateHomePageDto> GetById(int id);
        public Task<CreateUpdateHomePageDto> Create(CreateUpdateHomePageDto dto);
        public Task<CreateUpdateHomePageDto> Update(CreateUpdateHomePageDto dto);
        public Task<int> Delete(int id);
    }
}
