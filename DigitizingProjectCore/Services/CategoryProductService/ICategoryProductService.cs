using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.CategoryProductService
{
    public interface ICategoryProductService
    {
        public Task<List<CategoryViewModel>> GetAll();
        public Task<CategoryForProduct> GetById(int id);
        public Task<CreateUpdateCategoryDto> Create(CreateUpdateCategoryDto dto);
        public Task<CreateUpdateCategoryDto> Update(CreateUpdateCategoryDto dto);
        public Task<int> Delete(int id);
    }
}
