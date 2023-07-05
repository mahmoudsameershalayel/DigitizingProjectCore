namespace DigitizingProjectCore.Models
{
    public class CategoryForProduct : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public List<Product> _Products { get; set; }
    }
}
