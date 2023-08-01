using Microsoft.AspNetCore.Http;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdatePageDto
    {
        public int Id { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }
        public string Slug { get; set; }
        public string? ImageName { get; set; }
        public IFormFile? Image { get; set; }
        public bool IsActive { get; set; }
    }
}
