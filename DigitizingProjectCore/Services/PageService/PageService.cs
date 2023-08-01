using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.PageService
{
    public class PageService : IPageService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public PageService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context; 
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<List<PageViewModel>> GetAll()
        {
            var _Pages = await _context.Pages.Where(x => x.IsDelete == false).OrderBy(x => x.SortId).ToListAsync();
            var _PagesVM = _mapper.Map<List<PageViewModel>>(_Pages);
            return _PagesVM;
        }

        public async Task<List<PageViewModel>> GetAll(string? key, bool? isActive)
        {
            var _Pages = await _context.Pages.Where(x => x.IsDelete == false && (string.IsNullOrEmpty(key) || x.TitleEn.Contains(key) || x.TitleAr.Contains(key)) && (isActive == null || isActive == x.IsActive)).OrderBy(x => x.SortId).ToListAsync();
            var _PagesVM = _mapper.Map<List<PageViewModel>>(_Pages);
            return _PagesVM;
        }
        public async Task<CreateUpdatePageDto> GetById(int id)
        {
            var _Page = await _context.Pages.Where(x => x.IsDelete == false && x.Id == id).FirstOrDefaultAsync();
            var dto = _mapper.Map<CreateUpdatePageDto>(_Page);
            return dto;
        }
        public async Task<CreateUpdatePageDto> Create(CreateUpdatePageDto dto)
        {
            var _Page = _mapper.Map<Page>(dto);
            if (dto.Image != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                _Page.ImageName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _Page.Created_By = _UserId;
            _Page.Created_At = DateTime.Now;
            _Page.IsDelete = false;
            await _context.Pages.AddAsync(_Page);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdatePageDto> Update(CreateUpdatePageDto dto)
        {
            var _Page = await _context.Pages.Where(x => x.IsDelete == false && x.Id == dto.Id).FirstOrDefaultAsync();
            if (_Page != null)
            {
                var ImageName = _Page.ImageName;
                var _UpdatedPage = _mapper.Map(dto, _Page);
                _UpdatedPage.ImageName = ImageName;
                if (dto.Image != null)
                {
                    var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
                    var filePath = Path.Combine(uploadFolder, uniqueName);
                    dto.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    _UpdatedPage.ImageName = uniqueName;
                }
                var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
                _UpdatedPage.Updated_By = _UserId;
                _UpdatedPage.Updated_At = DateTime.Now;
                _context.Pages.Update(_UpdatedPage);
                await _context.SaveChangesAsync();
            }           
            return dto;
        }
        public async Task<int> Delete(int id)
        {
            var _Page = await _context.Pages.Where(x => x.IsDelete==false && x.Id == id).FirstOrDefaultAsync();
            if (_Page != null)
            {
                _Page.IsActive = false;
                _Page.IsDelete = true;
                _context.Pages.Update(_Page);
            }
            return await _context.SaveChangesAsync();
        }

    }
}
