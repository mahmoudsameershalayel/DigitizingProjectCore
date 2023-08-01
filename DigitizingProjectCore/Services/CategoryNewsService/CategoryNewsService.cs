using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.CategoryNewsService
{
    public class CategoryNewsService : ICategoryNewsService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public CategoryNewsService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<CategoryViewModel>> GetAll()
        {
            var _Categories = await _context.CategoryForNews.Where(x => x.IsDelete == false && x.IsActive == true).OrderBy(x => x.SortId).ToListAsync();
            var _CategoriesVM = _mapper.Map<List<CategoryViewModel>>(_Categories);
            return _CategoriesVM;
        }
        public async Task<List<CategoryViewModel>> GetAll(string? key)
        {
            var _Categories = await _context.CategoryForNews.Where(x => x.IsDelete == false && x.IsActive == true && (string.IsNullOrEmpty(key) || x.NameEn.Contains(key) || x.NameAr.Contains(key))).OrderBy(x => x.SortId).ToListAsync();
            var _CategoriesVM = _mapper.Map<List<CategoryViewModel>>(_Categories);
            return _CategoriesVM;
        }

        public async Task<CreateUpdateCategoryDto> GetById(int id)
        {
            var _Category = await _context.CategoryForNews.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Category == null)
            {
                throw new Exception("Not Found!!");
            }
            var dto = _mapper.Map<CreateUpdateCategoryDto>(_Category);
            return dto;
        }
        public async Task<CreateUpdateCategoryDto> Create(CreateUpdateCategoryDto dto)
        {
            var _Category = _mapper.Map<CategoryForNews>(dto);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Category.Created_By = _UserId;
            _Category.Created_At = DateTime.Now;
            _Category.IsDelete = false;
            await _context.CategoryForNews.AddAsync(_Category);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateCategoryDto> Update(CreateUpdateCategoryDto dto)
        {
            var _Category = await _context.CategoryForNews.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Category != null)
            {
                var _UpdateCategory = _mapper.Map(dto, _Category);
                var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
                _UpdateCategory.Updated_By = _UserId;
                _UpdateCategory.Updated_At = DateTime.Now;
                _context.CategoryForNews.Update(_UpdateCategory);
                await _context.SaveChangesAsync();
            }
            return dto;
        }

        public async Task<int> Delete(int id)
        {
            var _Category = await _context.CategoryForNews.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Category != null)
            {
                _Category.IsDelete = true;
                _context.CategoryForNews.Update(_Category);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
