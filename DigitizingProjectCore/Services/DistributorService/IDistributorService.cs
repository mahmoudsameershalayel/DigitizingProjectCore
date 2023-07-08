using DigitizingProjectCore.Areas.Admin.ViewModel;

namespace DigitizingProjectCore.Services.DistributorService
{
    public interface IDistributorService
    {
        public Task<List<DistributorViewModel>> GetAll();
        public Task<DistributorViewModel> GetById(int id);
        public Task<CityViewModel> Create(CityViewModel vm);
        public Task<CityViewModel> Update(CityViewModel vm);
        public Task<int> Delete(int id);
    }
}
