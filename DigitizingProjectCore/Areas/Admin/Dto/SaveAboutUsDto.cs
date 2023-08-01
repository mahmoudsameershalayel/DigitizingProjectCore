namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class SaveAboutUsDto
    {
        public int Id { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }
        public string WhyUsAr { get; set; }
        public string WhyUsEn { get; set; }
        public string ExperienceAr { get; set; }
        public string ExperienceEn { get; set; }
        public string ApprouchAr { get; set; }
        public string ApprouchEn { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public bool ShowServices { get; set; }
        public bool ShowPartners { get; set; }
        public string ApprouchTitlesAr { get; set; }
        public string ApprouchTitlesEn { get; set; }
        public string ExperienceTitlesAr { get; set; }
        public string ExperienceTitlesEn { get; set; }
        public string WhyUsTitlesAr { get; set; }
        public string WhyUsTitlesEn { get; set; }
        public string VisionTitlesAr { get; set; }
        public string VisionTitlesEn { get; set; }
        public string VisionAr { get; set; }
        public string VisionEn { get; set; }
    }
}
