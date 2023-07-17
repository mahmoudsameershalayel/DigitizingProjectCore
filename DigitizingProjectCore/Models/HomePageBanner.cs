namespace DigitizingProjectCore.Models
{
    public class HomePageBanner : BaseEntity
    {
        public int Id { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public string SubTitleEn { get; set; }
        public string SubTitleAr { get; set; }
        public string SummaryEn { get; set; }
        public string SummaryAr { get; set; }
        public string? BackgroundImageName { get; set; }
        public string VideoURL { get; set; }
        public string URLAr { get; set; }
        public string URLEn { get; set; }        
        public bool ShowText { get; set; }
    }
}
