using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
    
namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateProductDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string SummaryAr { get; set; }
        public string SummaryEn { get; set; }
        public string DetailsAr { get; set; }
        public string DetailsEn { get; set; }
        public IFormFile LogoImage { get; set; }
        public IFormFile PDFFile { get; set; }
        public IFormFile DocFile { get; set; }
        public string? LogoImageName { get; set; }
        public string? PDFFileName { get; set; }
        public string? DocFileName { get; set; }
        public int SortId { get; set; }
        public bool IsActive { get; set; }
    }
    public class AddProductWithCategoryAndBrand : CreateUpdateProductDto
    {
        public IEnumerable<SelectListItem> _Categories { get; set; }
        public IEnumerable<SelectListItem> _Brands { get; set; }

        public void InjectCategories(List<CategoryForProduct> categories)
        {
            List<SelectListItem> ListOfCategories = new List<SelectListItem>();
            foreach (var category in categories)
            {
                ListOfCategories.Add(
                new SelectListItem { Text = category.NameEn, Value = category.Id.ToString() }
                );
            }
            _Categories = ListOfCategories;
        }
        public void InjectBrands(List<Brand> Brands)
        {
            List<SelectListItem> ListOfBrands = new List<SelectListItem>();
            foreach (var Brand in Brands)
            {
                ListOfBrands.Add(
                new SelectListItem { Text = Brand.NameEn, Value = Brand.Id.ToString() }
                );
            }
            _Brands = ListOfBrands;
        }
    }
}
