using AutoMapper;
using Azure;
using Castle.MicroKernel.Registration;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace DigitizingProjectCore.Services.CategoryProductService
{
    public class CategoryProductService : ICategoryProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public CategoryProductService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<CategoryViewModel>> GetAll()
        {
            var _Categories = await _context.CategoryForProducts.Where(x => x.IsDelete == false).OrderBy(x => x.SortId).ToListAsync();
            var _CategoriesVM = _mapper.Map<List<CategoryViewModel>>(_Categories);
            return _CategoriesVM;
        }

        public async Task<CreateUpdateCategoryDto> GetById(int id)
        {
            var _Category = await _context.CategoryForProducts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Category == null) {
                throw new Exception("Not Found!!");
            }
            var dto = _mapper.Map<CreateUpdateCategoryDto>(_Category);
            return dto;
        }
        public async Task<CreateUpdateCategoryDto> Create(CreateUpdateCategoryDto dto)
        {
            var _Category = _mapper.Map<CategoryForProduct>(dto);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Category.Created_By = _UserId;
            _Category.Created_At = DateTime.Now;
            _Category.IsActive = true;
            _Category.IsDelete = false;
            await _context.CategoryForProducts.AddAsync(_Category);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateCategoryDto> Update(CreateUpdateCategoryDto dto)
        {
            var _Category = await _context.CategoryForProducts.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Category != null)
            {
                var _UpdateCategory = _mapper.Map(dto, _Category);
                var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
                _UpdateCategory.Updated_By = _UserId;
                _UpdateCategory.Updated_At = DateTime.Now;
                _context.CategoryForProducts.Update(_UpdateCategory);
                await _context.SaveChangesAsync();
            }
            return dto;
        }

        public async Task<int> Delete(int id)
        {
            var _Category = await _context.CategoryForProducts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Category != null)
            {
                _Category.IsDelete = true;
                _context.CategoryForProducts.Update(_Category);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
