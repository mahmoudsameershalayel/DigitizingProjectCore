using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.HomeBageService
{
    public class HomePageService : IHomePageService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomePageService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }
        public async Task<List<HomePageViewModel>> GetAll()
        {
            var _Banners = await _context.HomePageBanners.Where(x => x.IsDelete == false && x.IsActive == true).OrderBy(x => x.SortId).ToListAsync();
            var _BannersVM = _mapper.Map<List<HomePageViewModel>>(_Banners);
            return _BannersVM;
        }

        public async Task<CreateUpdateHomePageDto> GetById(int id)
        {
            var _Banner = await _context.HomePageBanners.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Banner == null)
            {
                throw new Exception("Not Found!!");
            }
            var dto = _mapper.Map<CreateUpdateHomePageDto>(_Banner);
            return dto;
        }
        public async Task<CreateUpdateHomePageDto> Create(CreateUpdateHomePageDto dto)
        {
            var _Banner = _mapper.Map<HomePageBanner>(dto);
            if (dto.BackgroundImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.BackgroundImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.BackgroundImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _Banner.BackgroundImageName = uniqueName;
            }         
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Banner.Created_By = _UserId;
            _Banner.Created_At = DateTime.Now;
            _Banner.IsActive = true;
            _Banner.IsDelete = false;
            await _context.HomePageBanners.AddAsync(_Banner);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateHomePageDto> Update(CreateUpdateHomePageDto dto)
        {
            var _Banner = await _context.HomePageBanners.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Banner == null)
            {
                throw new Exception("Not Found!!");
            }
            var BackgroundImageName = _Banner.BackgroundImageName;
            var _UpdatedBanner = _mapper.Map(dto, _Banner);
            _UpdatedBanner.BackgroundImageName = BackgroundImageName;
            if (dto.BackgroundImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.BackgroundImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.BackgroundImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _UpdatedBanner.BackgroundImageName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _UpdatedBanner.Updated_By = _UserId;
            _UpdatedBanner.Updated_At = DateTime.Now;
            _context.HomePageBanners.Update(_UpdatedBanner);
            _context.SaveChanges();
            return dto;
        }

        public async Task<int> Delete(int id)
        {
            var _Banner = await _context.HomePageBanners.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Banner != null)
            {
                _Banner.IsActive = false;
                _Banner.IsDelete = true;
                _context.HomePageBanners.Update(_Banner);
            }
            return await _context.SaveChangesAsync();
        }        
       
    }
}
