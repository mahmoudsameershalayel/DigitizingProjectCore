namespace DigitizingProjectCore.Models
{
    public class Service : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string SummaryAr { get; set; }
        public string SummaryEn { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }
        public string PDFFile { get; set; }
        public string DocFile { get; set; }
        public string LogoImage { get; set; }
        public int? ServiceCategoryId { get; set; }
        public CategoryForService _Category { get; set; }
    }
}
