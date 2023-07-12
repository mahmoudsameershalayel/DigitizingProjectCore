using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace DigitizingProjectCore.Services.DistributorService
{
    public class DistributorService : IDistributorService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public DistributorService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<DistributorViewModel>> GetAll()
        {
            var _Distributors = await _context.Distributors.Where(x => x.IsDelete == false && x.IsActive == true).OrderBy(x => x.SortId).Include(x => x.City).ToListAsync();
            var _DistributorsVM = _mapper.Map<List<DistributorViewModel>>(_Distributors);
            return _DistributorsVM;
        }

        public async Task<Distributor> GetById(int id)
        {
            var _Distributor = await _context.Distributors.Where(x => x.Id == id).Include(x => x.City). FirstOrDefaultAsync();
            if (_Distributor == null)
            {
                throw new Exception("Not Found!!");
            }
            return _Distributor;
        }
        public async Task<CreateUpdateDistributorDto> Create(CreateUpdateDistributorDto dto)
        {
            var _Distributor = _mapper.Map<Distributor>(dto);
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Distributor.Created_By = _UserId;
            _Distributor.Created_At = DateTime.Now;
            _Distributor.IsActive = true;
            _Distributor.IsDelete = false;
            await _context.Distributors.AddAsync(_Distributor);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<CreateUpdateDistributorDto> Update(CreateUpdateDistributorDto dto)
        {
            var _Distributor = await _context.Distributors.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Distributor == null)
            {
                throw new Exception("Not Found!!");
            }
            var _UpdateDistributor = _mapper.Map(dto, _Distributor);
            _context.Distributors.Update(_UpdateDistributor);
            _context.SaveChanges();
            return dto;
        }
        public async Task<int> Delete(int id)
        {
            var _Distributor = await _context.Distributors.Where(x => x.Id == id).FirstAsync();
            if (_Distributor != null)
            {
                _Distributor.IsActive = false;
                _Distributor.IsDelete = true;
                _context.Distributors.Update(_Distributor);
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<CreateUpdateDistributorDto> InjectCities()
        {
            var _Cities = await _context.Cities.Where(x => x.IsDelete == false).ToListAsync();
            var dto = new AddDistibutorWithCity();
            dto.InjectCities(_Cities);
            return dto;
        }
    }
}
