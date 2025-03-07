﻿namespace DigitizingProjectCore.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string SummaryEn { get; set; }
        public string SummaryAr { get; set; }
        public string DetailsEn { get; set; }
        public string DetailsAr { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? PDFFileName { get; set; }
        public string? DocFileName { get; set; }
        public string? LogoImageName { get; set; }
        public int? CategoryId { get; set; }
        public CategoryForProduct Category { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<SolutionProducts> SolutionProducts { get; set; }
    }
}
