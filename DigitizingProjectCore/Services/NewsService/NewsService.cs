using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Areas.Admin.ViewModel;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Services.NewsService
{
    public class NewsService : INewsService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;

        public NewsService(ApplicationDbContext context, IMapper mapper, IWebHostEnvironment hostEnvironment, IHttpContextAccessor contextAccessor, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
            _contextAccessor = contextAccessor;
            _userManager = userManager;
        }
        public async Task<List<NewsViewModel>> GetAll()
        {
            var _News = await _context.News.Where(x => x.IsDelete == false).OrderBy(x => x.SortId).Include(c => c.Category).ToListAsync();
            var _NewsVM = _mapper.Map<List<NewsViewModel>>(_News);
            return _NewsVM;
        }
        public async Task<List<NewsViewModel>> GetAll(string? key, int? categoryId, bool? isActive)
        {
            var _News = await _context.News.Where(x => x.IsDelete == false && (string.IsNullOrEmpty(key) || x.TitleEn.Contains(key) || x.TitleAr.Contains(key)) && (categoryId == null || x.Category.Id == categoryId) && (isActive == null || x.IsActive == isActive)).OrderBy(x => x.SortId).Include(c => c.Category).ToListAsync();
            var _NewsVM = _mapper.Map<List<NewsViewModel>>(_News);
            return _NewsVM;
        }
        public async Task<CreateUpdateNewsDto> GetDtoById(int id)
        {
            var _News = await _context.News.Where(x => x.Id == id).Include(c => c.Category).FirstOrDefaultAsync();
            if (_News == null)
            {
                throw new Exception("Not Found!!");
            }
            var _NewsDto = _mapper.Map<CreateUpdateNewsDto>(_News);
            return _NewsDto;
        }

        public async Task<News> GetNewsById(int id)
        {
            var _News = await _context.News.Where(x => x.Id == id).Include(c => c.Category).FirstOrDefaultAsync();
            if (_News == null)
            {
                throw new Exception("Not Found!!");
            }
            return _News;
        }

        public async Task<CreateUpdateNewsDto> Create(CreateUpdateNewsDto dto)
        {
            var _News = _mapper.Map<News>(dto);
            if (dto.LogoImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _News.LogoImageName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _News.Created_By = _UserId;
            _News.Created_At = DateTime.Now;
            _News.IsDelete = false;
            await _context.News.AddAsync(_News);
            await _context.SaveChangesAsync();
            return dto;
        }
        public async Task<CreateUpdateNewsDto> Update(CreateUpdateNewsDto dto)
        {
            var _News = await _context.News.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
            if (_News == null)
            {
                throw new Exception("Not Found!!");
            }
            var LogoImageName = _News.LogoImageName;
            var _UpdateNews = _mapper.Map(dto, _News);
            _UpdateNews.LogoImageName = LogoImageName;
            if (dto.LogoImage != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.LogoImage.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.LogoImage.CopyTo(new FileStream(filePath, FileMode.Create));
                _UpdateNews.LogoImageName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _UpdateNews.Updated_By = _UserId;
            _UpdateNews.Updated_At = DateTime.Now;
            _context.News.Update(_UpdateNews);
            _context.SaveChanges();
            return dto;
        }
        public async Task<int> Delete(int id)
        {
            var _News = await _context.News.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (_News != null)
            {
                _News.IsActive = false;
                _News.IsDelete = true;
                _context.News.Update(_News);
            }
            return await _context.SaveChangesAsync();
        }


        public async Task<CreateUpdateNewsDto> InjectCategories()
        {
            var _Categories = await _context.CategoryForNews.Where(x => x.IsDelete == false).ToListAsync();
            var dto = new AddNewsWithCategory();
            dto.InjectCategories(_Categories);
            return dto;
        }


    }
}
