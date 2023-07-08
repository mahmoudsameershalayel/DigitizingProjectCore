using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public BrandService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<BrandViewModel>> GetAll()
        {
            var _Brands = await _context.Brands.ToListAsync();
            var _BrandsVM = _mapper.Map<List<BrandViewModel>>(_Brands);
            return _BrandsVM;
        }

        public async Task<BrandViewModel> GetById(int id)
        {
            var _Brand = await _context.Brands.Where(x => x.Id == id).FirstOrDefaultAsync();
            var _BrandVM = _mapper.Map<BrandViewModel>(_Brand);
            return _BrandVM;
        }
        public async Task<CreateUpdateBrandDto> Create(CreateUpdateBrandDto dto)
        {
            var _Brand = _mapper.Map<Brand>(dto);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Brand.Created_By = _UserId;
            _Brand.Created_At = DateTime.Now;
            _Brand.IsActive = true;
            _Brand.IsDelete = false;
            await _context.Brands.AddAsync(_Brand);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateBrandDto> Update(CreateUpdateBrandDto dto)
        {
            var _Brand = await _context.Brands.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Brand == null) {
                throw new Exception("Not Found!!");
            }
            var _UpdatedBrand = _mapper.Map(dto, _Brand);
            _context.Brands.Update(_UpdatedBrand);
            await _context.SaveChangesAsync();
            return dto;

        }
        public async Task<int> Delete(int id)
        {
            var _Brand = await _context.Brands.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Brand == null)
            {
                throw new Exception("Not Found!!");
            }
            _context.Brands.Remove(_Brand);
            return await _context.SaveChangesAsync();
            return 0;

        }

        public async Task<List<BrandViewModel>> GetByName(string name)
        {
            var _brands = await _context.Brands.Where(x => x.NameEn.Contains(name) || x.NameAr.Contains(name)).ToListAsync();
            var _brandVM = _mapper.Map<List<BrandViewModel>>(_brands);
            return _brandVM;
        }
    }
}
