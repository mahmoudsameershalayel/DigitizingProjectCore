using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.CategoryNewsService
{
    public interface ICategoryNewsService
    {
        public Task<List<CategoryViewModel>> GetAll();
        public Task<List<CategoryViewModel>> GetAll(string? key);
        public Task<CreateUpdateCategoryDto> GetById(int id);
        public Task<CreateUpdateCategoryDto> Create(CreateUpdateCategoryDto dto);
        public Task<CreateUpdateCategoryDto> Update(CreateUpdateCategoryDto dto);
        public Task<int> Delete(int id);
    }
}
