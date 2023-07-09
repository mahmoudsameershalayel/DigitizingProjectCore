using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.ServiceService
{
    public class ServiceService : IServiceService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public ServiceService(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }
        public async Task<List<ServiceViewModel>> GetAll()
        {
            var _Services = await _context.Services.Include(c => c._Category).ToListAsync();
            var _ServicesVM = _mapper.Map<List<ServiceViewModel>>(_Services);
            return _ServicesVM;
        }

        public async Task<Service> GetById(int id)
        {
            var _Service = await _context.Services.Where(x => x.Id == id).Include(c => c._Category).FirstOrDefaultAsync();
            if (_Service == null)
            {
                throw new Exception("Not Found!!");
            }
            return _Service;
        }
        public async Task<CreateUpdateServiceDto> Create(CreateUpdateServiceDto dto)
        {
            var _Service = _mapper.Map<Service>(dto);
            if (dto.LogoImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _Service.LogoImage = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Service.Created_By = _UserId;
            _Service.Created_At = DateTime.Now;
            _Service.IsActive = true;
            _Service.IsDelete = false;
            await _context.Services.AddAsync(_Service);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateServiceDto> Update(CreateUpdateServiceDto dto)
        {
            var _Service = await _context.Services.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Service == null)
            {
                throw new Exception("Not Found!!");
            }
            if (dto.LogoImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _Service.LogoImage = uniqueName;
            }
            var _UpdateService = _mapper.Map(dto, _Service);
            _context.Services.Update(_UpdateService);
            _context.SaveChanges();
            return dto;
        }
        public async Task<int> Delete(int id)
        {
            var _Service = await _context.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Service == null)
            {
                throw new Exception("Not Found!!");
            }
            _context.Services.Remove(_Service);
            return await _context.SaveChangesAsync();
        }
        public async Task<CreateUpdateServiceDto> InjectCategories()
        {
            var _Categories = await _context.CategoryForServices.ToListAsync();
            var dto = new AddServiceWithCategory();
            dto.InjectCategories(_Categories);
            return dto;
        }
    }
}
