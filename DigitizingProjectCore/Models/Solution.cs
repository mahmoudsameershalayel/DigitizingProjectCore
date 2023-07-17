namespace DigitizingProjectCore.Models
{
    public class Solution : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; } = string.Empty;
        public string NameEN { get; set; } = string.Empty;
        public string DetailsAr { get; set; } = string.Empty;
        public string DetailsEn { get; set; } = string.Empty;
        public string PDFFileName { get; set; } = string.Empty;
        public string DocFileName { get; set; } = string.Empty;
        public string LogoImageName { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public CategoryForProduct Category { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<SolutionProducts> SolutionProducts { get; set; } = new List<SolutionProducts>();
    }
}
