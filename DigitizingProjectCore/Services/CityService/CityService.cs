using AutoMapper;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.CityService
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public CityService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<CityViewModel>> GetAll()
        {
            var _Cities = await _context.Cities.ToListAsync();
            var _CitiesVM = _mapper.Map<List<CityViewModel>>(_Cities);
            return _CitiesVM;
        }

        public async Task<CityViewModel> GetById(int id)
        {
            var _City = await _context.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();
            var _CityVM = _mapper.Map<CityViewModel>(_City);
            return _CityVM;
        }
        public async Task<CityViewModel> Create(CityViewModel vm)
        {
            var _City = _mapper.Map<City>(vm);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _City.Created_By = _UserId;
            _City.Created_At = DateTime.Now;
            _City.IsActive = true;
            _City.IsDelete = false;
            await _context.Cities.AddAsync(_City);
            await _context.SaveChangesAsync();
            return vm;
        }
        public async Task<CityViewModel> Update(CityViewModel vm)
        {
            var _City = await _context.Cities.Where(x => x.Id == vm.Id).FirstOrDefaultAsync();
            if (_City != null)
            {
                var _UpdateCity = _mapper.Map(vm, _City);
                var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
                _UpdateCity.Updated_By = _UserId;
                _UpdateCity.Updated_At = DateTime.Now;
                _context.Cities.Update(_UpdateCity);
                await _context.SaveChangesAsync();
            }
            return vm;
        }
        public async Task<int> Delete(int id)
        {
            var _City = await _context.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_City != null) {
                _context.Cities.Remove(_City);
            }
            return await _context.SaveChangesAsync();
        }




    }
}
