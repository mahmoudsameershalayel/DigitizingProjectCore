namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
