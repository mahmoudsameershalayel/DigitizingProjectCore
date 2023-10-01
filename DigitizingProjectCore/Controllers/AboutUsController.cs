using AutoMapper;
using DigitizingProjectCore.Areas.Admin.Dto;
using DigitizingProjectCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitizingProjectCore.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AboutUsController(ApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var item = await _context.AboutUs.FirstOrDefaultAsync();
            var dto = _mapper.Map<SaveAboutUsDto>(item);
            if (item == null)
                item = new Models.AboutUs();
            else
            {
                try
                {
                    var jsonAr = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(item.TitlesAr);
                    var jsonEn = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(item.TitlesEn);
                    dto.ApprouchTitlesAr = jsonAr.ApprouchTitleAr.ToString();
                    dto.ExperienceTitlesAr = jsonAr.ExperienceTitleAr.ToString();
                    dto.WhyUsTitlesAr = jsonAr.WhyUsTitleAr.ToString();
                    dto.WhyUsTitlesEn = jsonEn.WhyUsTitleEn.ToString();
                    dto.ExperienceTitlesEn = jsonEn.ExperienceTitleEn.ToString();
                    dto.ApprouchTitlesEn = jsonEn.ApprouchTitleEn.ToString();
                    dto.VisionTitlesAr = jsonAr.VisionTitleAr.ToString();
                    dto.VisionTitlesEn = jsonEn.VisionTitleEn.ToString();
                }
                catch { }
            }
            return View(dto);
        }
    }
}
