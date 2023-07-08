using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;

namespace DigitizingProjectCore.Services.BrandServices
{
    public interface IBrandService
    {
        public Task<List<BrandViewModel>> GetAll();
        public Task<BrandViewModel> GetById(int id);
        public Task<List<BrandViewModel>> GetByName(string name);
        public Task<CreateUpdateBrandDto> Create(CreateUpdateBrandDto dto);
        public Task<CreateUpdateBrandDto> Update(CreateUpdateBrandDto dto);
        public Task<int> Delete(int id);
    }
}
