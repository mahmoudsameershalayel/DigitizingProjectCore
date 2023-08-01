using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

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
            var _Services = await _context.Services.Where(x => x.IsDelete == false).OrderBy(x => x.SortId).Include(c => c.Category).ToListAsync();
            var _ServicesVM = _mapper.Map<List<ServiceViewModel>>(_Services);
            return _ServicesVM;
        }
        public async Task<List<ServiceViewModel>> GetAll(string? key, int? categoryId, bool? isActive)
        {
            var _Services = await _context.Services.Where(x => x.IsDelete == false && (string.IsNullOrEmpty(key) || x.NameEn.Contains(key) || x.NameAr.Contains(key)) && (categoryId == null || x.Category.Id == categoryId) && (isActive == null || x.IsActive == isActive)).OrderBy(x => x.SortId).Include(c => c.Category).ToListAsync();
            var _ServicesVM = _mapper.Map<List<ServiceViewModel>>(_Services);
            return _ServicesVM;
        }
        public async Task<CreateUpdateServiceDto> GetDtoById(int id)
        {
            var _Service = await _context.Services.Where(x => x.Id == id).Include(c => c.Category).FirstOrDefaultAsync();
            if (_Service == null)
            {
                throw new Exception("Not Found!!");
            }
            var _ServiceDto = _mapper.Map<CreateUpdateServiceDto>(_Service);
            return _ServiceDto;
        }
        public async Task<Service> GetServiceById(int id)
        {
            var _Service = await _context.Services.Where(x => x.Id == id).Include(c => c.Category).FirstOrDefaultAsync();
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
                _Service.LogoImageName = uniqueName;
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
                _Service.PDFFileName = uniqueName;
            }
            if (dto.DOCFile != null)
            {
                string ext = Path.GetExtension(dto.DOCFile.FileName);
                if (ext.ToLower() != ".doc")
                {
                    throw new Exception("Not File Type!!");
                }
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "DocFiles");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.DOCFile.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.DOCFile.CopyTo(new FileStream(filePath, FileMode.Create));
                _Service.DocFileName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Service.Created_By = _UserId;
            _Service.Created_At = DateTime.Now;
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
            var LogoImageName = _Service.LogoImageName;
            var PDFFileName = _Service.PDFFileName;
            var DocFileName = _Service.DocFileName;
            var _UpdateService = _mapper.Map(dto, _Service);
            _UpdateService.LogoImageName = LogoImageName;
            _UpdateService.PDFFileName = PDFFileName;
            _UpdateService.DocFileName = DocFileName;
            if (dto.LogoImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _UpdateService.LogoImageName = uniqueName;
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
                _UpdateService.PDFFileName = uniqueName;
            }
            if (dto.DOCFile != null)
            {
                string ext = Path.GetExtension(dto.DOCFile.FileName);
                if (ext.ToLower() != ".doc")
                {
                    throw new Exception("Not File Type!!");
                }
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "DocFiles");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.DOCFile.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.DOCFile.CopyTo(new FileStream(filePath, FileMode.Create));
                _UpdateService.DocFileName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _UpdateService.Updated_By = _UserId;
            _UpdateService.Updated_At = DateTime.Now;
            _context.Services.Update(_UpdateService);
            _context.SaveChanges();
            return dto;
        }
        public async Task<int> Delete(int id)
        {
            var _Service = await _context.Services.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_Service != null)
            {
                _Service.IsDelete = true;
                _context.Services.Update(_Service);
            }
            return await _context.SaveChangesAsync();
        }
        public async Task<CreateUpdateServiceDto> InjectCategories()
        {
            var _Categories = await _context.CategoryForServices.Where(x => x.IsDelete == false). ToListAsync();
            var dto = new AddServiceWithCategory();
            dto.InjectCategories(_Categories);
            return dto;
        }

       
    }
}
