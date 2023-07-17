using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;

namespace DigitizingProjectCore.Services.CategoryProductService
{
    public interface ICategoryProductService
    {
        public Task<List<CategoryViewModel>> GetAll();
        public Task<CreateUpdateCategoryDto> GetById(int id);
        public Task<CreateUpdateCategoryDto> Create(CreateUpdateCategoryDto dto);
        public Task<CreateUpdateCategoryDto> Update(CreateUpdateCategoryDto dto);
        public Task<int> Delete(int id);
    }
}
