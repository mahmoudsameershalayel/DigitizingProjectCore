using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using CityViewModel = DigitizingProjectCore.Areas.Admin.ViewModel.CityViewModel;

namespace DigitizingProjectCore.Services.CityService
{
    public interface ICityService
    {
        public Task<List<CityViewModel>> GetAll();
        public Task<CityViewModel> GetById(int id);
        public Task<CityViewModel> Create(CityViewModel vm);
        public Task<CityViewModel> Update(CityViewModel vm);
        public Task<int> Delete(int id);
    }
}
