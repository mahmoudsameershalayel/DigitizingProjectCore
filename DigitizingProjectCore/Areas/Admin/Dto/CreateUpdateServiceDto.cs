using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateServiceDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name (English) is required")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "Name (Arabic) is required")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public int? SortId { get; set; }
        [Required(ErrorMessage = "Summary (English) is required")]
        public string SummaryEn { get; set; }
        [Required(ErrorMessage = "Summary (Arabic) is required")]
        public string SummaryAr { get; set; }
        [Required(ErrorMessage = "Details (English) is required")]
        public string DetailsEn { get; set; }
        [Required(ErrorMessage = "Details (Arabic) is required")]
        public string DetailsAr { get; set; }
        [Required(ErrorMessage = "Logo Image is required")]
        public IFormFile LogoImage { get; set; }
        [Required(ErrorMessage = "PDF File is required")]
        public IFormFile PDFFile { get; set; }
        [Required(ErrorMessage = "DOC File is required")]
        public IFormFile DOCFile { get; set; }
        public bool  IsActive { get; set; }

    }
    public class AddServiceWithCategory : CreateUpdateServiceDto
    {
        public IEnumerable<SelectListItem> _Categories { get; set; }

        public void InjectCategories(List<CategoryForService> categories)
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
    }
}
