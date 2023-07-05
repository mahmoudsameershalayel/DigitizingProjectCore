using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace DigitizingProjectCore.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
        }
        public async Task<List<ProductViewModel>> GetAll()
        {
            var _products = await _context.Products.ToListAsync();
            var _productsVM = _mapper.Map<List<ProductViewModel>>(_products);
            return _productsVM;
        }

        public async Task<ProductViewModel> GetById(int id)
        {
            var _product = await _context.Products.Where(x => x.Id == id).FirstAsync();
            var _productVM = _mapper.Map<ProductViewModel>(_product);
            return _productVM;
        }
        public async Task<CreateUpdateProductDto> Create(CreateUpdateProductDto dto)
        {
            var _product = _mapper.Map<Product>(dto);
            if (dto.LogoImage != null) {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _product.LogoImage = uniqueName;
            }
            await _context.Products.AddAsync(_product);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateProductDto> Update(CreateUpdateProductDto dto)
        {
            var _product = await _context.Products.Where(x => x.Id == dto.Id).FirstAsync();
            if (dto.LogoImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _product.LogoImage = uniqueName;
            }
            var _Updateproduct = _mapper.Map(dto, _product);
            _context.Products.Update(_Updateproduct);
            _context.SaveChanges();
            return dto;
        }

        public async Task<int> Delete(int id)
        {
            var _product = await _context.Products.Where(x => x.Id == id).FirstAsync();
            if (_product == null)
            {
                throw new Exception("Not Found!!");
            }
            _context.Products.Remove(_product);
            return await _context.SaveChangesAsync();
        }

        public async Task<CreateUpdateProductDto> InjectCategoriesAndBrands()
        {
            var _Categories = await _context.CategoryForProducts.ToListAsync();
            var _Brands = await _context.Brands.ToListAsync();
            var dto = new AddProductWithCategoryAndBrand();
            dto.InjectCategories(_Categories);
            dto.InjectBrands(_Brands);
            return dto;
        }
    }
}
