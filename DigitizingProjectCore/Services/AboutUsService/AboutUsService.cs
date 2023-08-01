using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace DigitizingProjectCore.Services.AboutUsService
{
    public class AboutUsService : IAboutUsService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        public AboutUsService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _hostEnvironment = hostEnvironment;
        }
        public async Task<SaveAboutUsDto> Get()
        {
            var _AboutUs = await _context.AboutUs.FirstOrDefaultAsync();
            var dto = _mapper.Map<SaveAboutUsDto>(_AboutUs);
            return dto;
        }

        public async Task<SaveAboutUsDto> Save(SaveAboutUsDto dto)
        {
            var _AboutUs = await _context.AboutUs.FirstOrDefaultAsync();
            if (_AboutUs == null)
            {
                var _AboutUsCreate = _mapper.Map<AboutUs>(dto);
                if (dto.Image != null)
                {
                    var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                    var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
                    var filePath = Path.Combine(uploadFolder, uniqueName);
                    dto.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    _AboutUsCreate.ImageName = uniqueName;
                }
                _AboutUsCreate.TitlesAr = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    ApprouchTitleAr = dto.ApprouchTitlesAr,
                    ExperienceTitleAr = dto.ExperienceTitlesAr,
                    WhyUsTitleAr = dto.WhyUsTitlesAr,
                    VisionTitleAr = dto.VisionTitlesAr,
                });
                _AboutUsCreate.TitlesEn = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    ApprouchTitleEn = dto.ApprouchTitlesEn,
                    ExperienceTitleEn = dto.ExperienceTitlesEn,
                    WhyUsTitleEn = dto.WhyUsTitlesEn,
                    VisionTitleEn = dto.VisionTitlesEn,
                });
                await _context.AboutUs.AddAsync(_AboutUsCreate);
                await _context.SaveChangesAsync();
                return dto;
            }
            var id = _AboutUs.Id;
            var imageName = _AboutUs.ImageName;
            var _AboutUsUpdate = _mapper.Map(dto, _AboutUs);
            _AboutUsUpdate.ImageName = imageName;
            if (dto.Image != null)
            {
                var uploadFolder = Path.Combine(_hostEnvironment.WebRootPath, "Images");
                var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Image.FileName);
                var filePath = Path.Combine(uploadFolder, uniqueName);
                dto.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                _AboutUsUpdate.ImageName = uniqueName;
            }
            var _UserId = _userManager.GetUserId(_contextAccessor.HttpContext.User);
            _AboutUsUpdate.Id = id;
            _AboutUsUpdate.Updated_By = _UserId;
            _AboutUsUpdate.Updated_At = DateTime.Now;
            _AboutUsUpdate.TitlesAr = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                ApprouchTitleAr = dto.ApprouchTitlesAr,
                ExperienceTitleAr = dto.ExperienceTitlesAr,
                WhyUsTitleAr = dto.WhyUsTitlesAr,
                VisionTitleAr = dto.VisionTitlesAr,
            });
            _AboutUsUpdate.TitlesEn = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                ApprouchTitleEn = dto.ApprouchTitlesEn,
                ExperienceTitleEn = dto.ExperienceTitlesEn,
                WhyUsTitleEn = dto.WhyUsTitlesEn,
                VisionTitleEn = dto.VisionTitlesEn,
            });
            _context.AboutUs.Update(_AboutUsUpdate);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
