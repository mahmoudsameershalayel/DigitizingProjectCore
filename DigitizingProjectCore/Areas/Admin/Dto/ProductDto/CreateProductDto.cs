using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto.ProductDto
{
    public class CreateProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name (Arabic) is required")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "Name (English) is required")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Brand is required")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Summary (Arabic) is required")]
        public string SummaryAr { get; set; }
        [Required(ErrorMessage = "Summary (English) is required")]
        public string SummaryEn { get; set; }
        [Required(ErrorMessage = "Details (Arabic) is required")]
        public string DetailsAr { get; set; }
        [Required(ErrorMessage = "Details (English) is required")]
        public string DetailsEn { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public IFormFile LogoImage { get; set; }
        public IFormFile? PDFFile { get; set; }
        public IFormFile? DocFile { get; set; }
        public string? LogoImageName { get; set; }
        public string? PDFFileName { get; set; }
        public string? DocFileName { get; set; }
        public int? SortId { get; set; }
        public bool IsActive { get; set; }
    }
    public class AddProductWithCategoryAndBrand : CreateProductDto
    {
        public IEnumerable<SelectListItem> _Categories { get; set; }
        public IEnumerable<SelectListItem> _Brands { get; set; }

        public void InjectCategories(List<CategoryForProduct> categories)
        {
            List<SelectListItem> ListOfCategories = new List<SelectListItem>();
            ListOfCategories.Add(
               new SelectListItem { Text = "Select Category", Value = null }
               );
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
            ListOfBrands.Add(
                 new SelectListItem { Text = "Select Brand", Value = null }
            );
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
