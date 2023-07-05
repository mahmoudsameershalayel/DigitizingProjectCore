using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;

namespace DigitizingProjectCore.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductViewModel>> GetAll();
        public Task<ProductViewModel> GetById(int id);
        public Task<CreateUpdateProductDto> Create(CreateUpdateProductDto dto);
        public Task<CreateUpdateProductDto> Update(CreateUpdateProductDto dto);
        public Task<CreateUpdateProductDto> InjectCategoriesAndBrands();
        public Task<int> Delete(int id);
    }
}
