using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.SolutionService
{
    public class SolutionService : ISolutionService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public SolutionService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<SolutionViewModel>> GetAll()
        {
            var _Solutions = await _context.Solutions.Where(x => x.IsDelete == false).OrderBy(x => x.SortId).Include(c => c.Category).Include(b => b.Brand).Include(x => x.SolutionProducts).ToListAsync();
            var _SolutionsVM = _mapper.Map<List<SolutionViewModel>>(_Solutions);
            return _SolutionsVM;
        }
        public async Task<List<SolutionViewModel>> GetAll(string? key)
        {
            var _Solutions = await _context.Solutions.Where(x => x.IsDelete == false && (string.IsNullOrEmpty(key) || x.NameEN.Contains(key) || x.NameAr.Contains(key))).OrderBy(x => x.SortId).Include(c => c.Category).Include(b => b.Brand).Include(x => x.SolutionProducts).ToListAsync();
            var _SolutionsVM = _mapper.Map<List<SolutionViewModel>>(_Solutions);
            return _SolutionsVM;
        }
        public async Task<Solution> GetById(int id)
        {
            var _Solution = await _context.Solutions.Where(x => x.Id == id).Include(c => c.Category).Include(b => b.Brand).Include(x => x.SolutionProducts).FirstOrDefaultAsync();
            if (_Solution == null)
            {
                throw new Exception("Not Found!!");
            }
            return _Solution;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            var _Products = await _context.Products.ToListAsync();
            return _Products;
        }


        public async Task<CreateUpdateSolutionDto> Create(CreateUpdateSolutionDto dto)
        {
            var _Solution = _mapper.Map<Solution>(dto);
            if (dto.LogoImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _Solution.LogoImageName = uniqueName;
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
                _Solution.PDFFileName = uniqueName;
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
                _Solution.DocFileName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Solution.Created_By = _UserId;
            _Solution.Created_At = DateTime.Now;
            _Solution.IsDelete = false;
            await _context.Solutions.AddAsync(_Solution);
            await _context.SaveChangesAsync();
            foreach (var id in dto.ProductIds)
            {
                await _context.SolutionProducts.AddAsync(new SolutionProducts
                {
                    SolutionId = _Solution.Id,
                    ProductId = id
                });
            }
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateSolutionDto> Update(CreateUpdateSolutionDto dto)
        {
            var _Solution = await _context.Solutions.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Solution == null)
            {
                throw new Exception("Not Found!!");
            }
            var LogoImageName = _Solution.LogoImageName;
            var PDFFileName = _Solution.PDFFileName;
            var DocFileName = _Solution.DocFileName;
            var _UpdateSolution = _mapper.Map(dto, _Solution);
            _UpdateSolution.LogoImageName = LogoImageName;
            _UpdateSolution.PDFFileName = PDFFileName;
            _UpdateSolution.DocFileName = DocFileName;
            if (dto.LogoImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _UpdateSolution.LogoImageName = uniqueName;
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
                _UpdateSolution.PDFFileName = uniqueName;
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
                _UpdateSolution.DocFileName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _UpdateSolution.Updated_By = _UserId;
            _UpdateSolution.Updated_At = DateTime.Now;
            _context.Solutions.Update(_UpdateSolution);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<int> Delete(int id)
        {
            var _Solution = await _context.Solutions.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Solution == null)
            {
                throw new Exception("Not Found!!");
            }
            _Solution.IsActive = false;
            _Solution.IsDelete = true;
            _context.Solutions.Update(_Solution);
            return await _context.SaveChangesAsync();
        }
        public async Task<AddSolutionWithCategoryAndBrandAndProduct> InjectCategoriesAndBrandsAndProducts()
        {
            var _Categories = await _context.CategoryForProducts.Where(x => x.IsDelete == false).ToListAsync();
            var _Brands = await _context.Brands.Where(x => x.IsDelete == false).ToListAsync();
            var _Products = await _context.Products.Where(x => x.IsDelete == false).ToListAsync();
            var dto = new AddSolutionWithCategoryAndBrandAndProduct();
            dto.InjectCategories(_Categories);
            dto.InjectBrands(_Brands);
            dto.InjectProducts(_Products);
            return dto;
        }

       
    }
}
