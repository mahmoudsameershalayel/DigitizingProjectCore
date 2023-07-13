namespace DigitizingProjectCore.Models
{
    public class CategoryForNews : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public List<News> _News { get; set; }
    }
}
