using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateSolutionDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name (Arabic) is required.")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "Name (English) is required.")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Brand is required.")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Product is required.")]
        public List<int> ProductsId { get; set; }
        [Required(ErrorMessage = "Details (Arabic) is required.")]
        public string DetailsAr { get; set; }
        [Required(ErrorMessage = "Details (English) is required.")]
        public string DetailsEn { get; set; }
        [Required(ErrorMessage = "Logo Image is required.")]
        public IFormFile LogoImage { get; set; }
        [Required(ErrorMessage = "PDF File is required.")]
        public IFormFile PDFFile { get; set; }
        [Required(ErrorMessage = "Doc File is required.")]
        public IFormFile DocFile { get; set; }
        public string? LogoImageName { get; set; }
        public string? PDFFileName { get; set; } 
        public string? DocFileName { get; set; }
        public int SortId { get; set; }
        public bool IsActive { get; set; }
    }
    public class AddSolutionWithCategoryAndBrandAndProduct : CreateUpdateSolutionDto
    {
        public IEnumerable<SelectListItem> _Categories { get; set; }
        public IEnumerable<SelectListItem> _Brands { get; set; }
        public IEnumerable<SelectListItem> _Products { get; set; }

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
        public void InjectProducts(List<Product> Products)
        {
            List<SelectListItem> ListOfProducts = new List<SelectListItem>();
            foreach (var Product in Products)
            {
                ListOfProducts.Add(
                new SelectListItem { Text = Product.NameEn, Value = Product.Id.ToString() }
                );
            }
            _Products = ListOfProducts;
        }
    }
}
