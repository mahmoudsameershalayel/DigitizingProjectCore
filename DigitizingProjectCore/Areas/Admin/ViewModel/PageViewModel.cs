namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created_At { get; set; }
    }
}
