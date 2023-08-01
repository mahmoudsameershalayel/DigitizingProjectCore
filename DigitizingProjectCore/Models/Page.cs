namespace DigitizingProjectCore.Models
{
    public class Page : BaseEntity
    {
        public int Id { get; set; }
        public string TitleAr { get; set; } 
        public string TitleEn { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }
        public string Slug { get; set; }
        public string ImageName { get; set; }
    }
}
