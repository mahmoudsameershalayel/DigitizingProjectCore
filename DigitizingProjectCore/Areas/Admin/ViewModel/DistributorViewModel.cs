namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class DistributorViewModel
    {
        public int Id { get; set; }
        public string NameEn { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string AddressEn { get; set; } = string.Empty;
        public string Phone { get; set; }= string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
