using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.CategoryServiceService
{
    public interface ICategoryServiceService
    {
        public Task<List<CategoryViewModel>> GetAll();
        public Task<CategoryForService> GetById(int id);
        public Task<CreateUpdateCategoryDto> Create(CreateUpdateCategoryDto dto);
        public Task<CreateUpdateCategoryDto> Update(CreateUpdateCategoryDto dto);
        public Task<int> Delete(int id);
    }
}
