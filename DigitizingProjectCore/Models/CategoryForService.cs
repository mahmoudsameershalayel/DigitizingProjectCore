namespace DigitizingProjectCore.Models
{
    public class CategoryForService : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public List<Service> _Services { get; set; }
        public int? ParentId { get; set; }
    }
}
