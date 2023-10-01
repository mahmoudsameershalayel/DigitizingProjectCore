using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.Dto.ProductDto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Services.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductViewModel>> GetAll();
        public Task<List<ProductViewModel>> GetAll(string? key, int? categoryId, int? brandId, bool? isActive);
        public Task<Product> GetById(int id);
        public Task<CreateProductDto> Create(CreateProductDto dto);
        public Task<UpdateProductDto> Update(UpdateProductDto dto);
        public Task<CreateProductDto> CreateInjectCategoriesAndBrands();
        public Task<UpdateProductDto> UpdateInjectCategoriesAndBrands();
        public Task<int> Delete(int id);
    }
}
