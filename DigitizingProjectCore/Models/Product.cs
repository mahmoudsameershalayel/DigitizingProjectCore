namespace DigitizingProjectCore.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string SummaryEn { get; set; }
        public string SummaryAr { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? PDFFile { get; set; }
        public string? DocFile { get; set; }
        public string? LogoImage { get; set; }
        public int? CategoryId { get; set; }
        public CategoryForProduct Category { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<SolutionProducts> _SolutionProducts { get; set; }
    }
}
