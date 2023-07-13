using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.SolutionService
{
    public interface ISolutionService
    {
        public Task<List<SolutionViewModel>> GetAll();
        public Task<Solution> GetById(int id);
        public Task<List<Product>> GetAllProducts();
        public Task<CreateUpdateSolutionDto> Create(CreateUpdateSolutionDto dto);
        public Task<CreateUpdateSolutionDto> Update(CreateUpdateSolutionDto dto);
        public Task<AddSolutionWithCategoryAndBrandAndProduct> InjectCategoriesAndBrandsAndProducts();
        public Task<int> Delete(int id);
    }
}
