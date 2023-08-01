namespace DigitizingProjectCore.Models
{
    public class AboutUs : BaseEntity
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
        public string? ImageName { get; set; }
        public bool ShowServices { get; set; }
        public bool ShowPartners { get; set; }
        public string TitlesAr { get; set; }
        public string TitlesEn { get; set; }
        public string VisionAr { get; set; }
        public string VisionEn { get; set; }
    }
}
