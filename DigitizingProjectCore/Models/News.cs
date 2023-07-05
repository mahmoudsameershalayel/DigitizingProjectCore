namespace DigitizingProjectCore.Models
{
    public class News : BaseEntity
    {
        public int Id { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string SummaryAr { get; set; }
        public string SummaryEn { get; set; }
        public string TagsAr { get; set; }
        public string TagsEn { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int? NewsCategoryId { get; set; }
        public CategoryForNews _Category { get; set; }

    }
}
