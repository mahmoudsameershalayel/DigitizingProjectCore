using Abp.Domain.Entities;
using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace DigitizingProjectCore.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public ProductService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<ProductViewModel>> GetAll()
        {
            var _products = await _context.Products.Where(x => x.IsDelete == false).OrderBy(x => x.SortId).Include(c => c.Category).Include(b => b.Brand).ToListAsync();
            var _productsVM = _mapper.Map<List<ProductViewModel>>(_products);
            return _productsVM;
        }
        public async Task<List<ProductViewModel>> GetAll(string? key, int? categoryId, int? brandId, bool? isActive)
        {
            var _products = await _context.Products.Where(x => x.IsDelete == false && (string.IsNullOrEmpty(key) || x.NameEn.Contains(key) || x.NameAr.Contains(key)) && (categoryId == null || x.Category.Id == categoryId) && (brandId == null || x.Brand.Id == brandId) && (isActive == null || x.IsActive == isActive)).OrderBy(x => x.SortId).Include(c => c.Category).Include(b => b.Brand).ToListAsync();
            var _productsVM = _mapper.Map<List<ProductViewModel>>(_products);
            return _productsVM;
        }
        public async Task<Product> GetById(int id)
        {
            var _product = await _context.Products.Where(x => x.Id == id).Include(c => c.Category).Include(b => b.Brand).FirstOrDefaultAsync();
            if (_product == null)
            {
                throw new Exception("Not Found!!");
            }
            return _product;
        }
        public async Task<CreateUpdateProductDto> Create(CreateUpdateProductDto dto)
        {
            var _product = _mapper.Map<Product>(dto);
            if (dto.LogoImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _product.LogoImageName = uniqueName;
            }
            if (dto.PDFFile != null)
            {
                string ext = Path.GetExtension(dto.PDFFile.FileName);
                if (ext.ToLower() != ".pdf")
                {
                    throw new Exception("Not File Type!!");
                }
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "PDFFiles");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.PDFFile.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.PDFFile.CopyTo(new FileStream(filePath, FileMode.Create));
                _product.PDFFileName = uniqueName;
            }
            if (dto.DocFile != null)
            {
                string ext = Path.GetExtension(dto.DocFile.FileName);
                if (ext.ToLower() != ".doc")
                {
                    throw new Exception("Not File Type!!");
                }
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "DocFiles");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.DocFile.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.DocFile.CopyTo(new FileStream(filePath, FileMode.Create));
                _product.DocFileName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _product.Created_By = _UserId;
            _product.Created_At = DateTime.Now;
            _product.IsDelete = false;
            await _context.Products.AddAsync(_product);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateProductDto> Update(CreateUpdateProductDto dto)
        {
            var _product = await _context.Products.Where(x => x.IsDelete == false && x.Id == dto.Id).FirstOrDefaultAsync();
            if (_product != null)
            {
                var LogoImageName = _product.LogoImageName;
                var PDFFileName = _product.PDFFileName;
                var DocFileName = _product.DocFileName;
                var _Updateproduct = _mapper.Map(dto, _product);
                _Updateproduct.LogoImageName = LogoImageName;
                _Updateproduct.PDFFileName = PDFFileName;
                _Updateproduct.DocFileName = DocFileName;
                if (dto.LogoImage != null)
                {
                    var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                    var filePath = Path.Combine(uploadFolder, uniqueName);
                    dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                    _Updateproduct.LogoImageName = uniqueName;
                }
                if (dto.PDFFile != null)
                {
                    string ext = Path.GetExtension(dto.PDFFile.FileName);
                    if (ext.ToLower() != ".pdf")
                    {
                        throw new Exception("Not File Type!!");
                    }
                    var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.PDFFile.FileName);
                    var filePath = Path.Combine(uploadFolder, uniqueName);
                    dto.PDFFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    _Updateproduct.PDFFileName = uniqueName;
                }
                if (dto.DocFile != null)
                {
                    string ext = Path.GetExtension(dto.DocFile.FileName);
                    if (ext.ToLower() != ".doc")
                    {
                        throw new Exception("Not File Type!!");
                    }
                    var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "DocFiles");
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.DocFile.FileName);
                    var filePath = Path.Combine(uploadFolder, uniqueName);
                    dto.DocFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    _Updateproduct.DocFileName = uniqueName;
                }
                var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
                _Updateproduct.Updated_By = _UserId;
                _Updateproduct.Updated_At = DateTime.Now;
                _context.Products.Update(_Updateproduct);
                await _context.SaveChangesAsync();
            }
            return dto;
        }

        public async Task<int> Delete(int id)
        {
            var _product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_product != null)
            {
                _product.IsActive = false;
                _product.IsDelete = true;
                _context.Products.Update(_product);
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<CreateUpdateProductDto> InjectCategoriesAndBrands()
        {
            var _Categories = await _context.CategoryForProducts.Where(x => x.IsDelete == false).ToListAsync();
            var _Brands = await _context.Brands.Where(x => x.IsDelete == false).ToListAsync();
            var dto = new AddProductWithCategoryAndBrand();
            dto.InjectCategories(_Categories);
            dto.InjectBrands(_Brands);
            return dto;
        }


    }
}
