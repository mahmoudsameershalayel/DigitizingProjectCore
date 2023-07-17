namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsPartner { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created_At { get; set; }
    }
}
