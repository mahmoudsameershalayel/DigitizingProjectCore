namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateHomePageDto
    {
        public int Id { get; set; }
        public string TitleEN { get; set; }
        public string TitleAr { get; set; }
        public string SubTitleEn { get; set; }
        public string SubTitleAr { get; set; }
        public string SummaryEn { get; set; }
        public string SummaryAr { get; set; }
        public string URLEn { get; set; }
        public string URLAr { get; set; }
        public string VideoURL { get; set; }
        public int SortId { get; set; }
        public IFormFile? BackgroundImage { get; set; }
        public string? BackgroundImageName { get; set; } 
        public bool ShowText { get; set; }
        public bool IsActive { get; set; }
    }
}
