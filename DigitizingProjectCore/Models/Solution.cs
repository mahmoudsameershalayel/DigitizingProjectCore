namespace DigitizingProjectCore.Models
{
    public class Solution : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEN { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }
        public string PDFFile { get; set; }
        public string DocFile { get; set; }
        public string LogoImage { get; set; }
        public int? ProductCategoryId { get; set; }
        public CategoryForProduct _Category { get; set; }
        public int? BrandId { get; set; }
        public Brand _Brand { get; set; }
        public List<SolutionProducts> _SolutionProducts { get; set; }


    }
}
