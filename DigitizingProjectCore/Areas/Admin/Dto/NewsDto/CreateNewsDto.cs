using DigitizingProjectCore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto.NewsDto
{
    public class CreateNewsDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title (English) is required")]
        public string TitleEn { get; set; }
        [Required(ErrorMessage = "Title (Arabic) is required")]
        public string TitleAr { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
        public int SortId { get; set; }
        [Required(ErrorMessage = "Summary (English) is required")]
        public string SummaryEn { get; set; }
        [Required(ErrorMessage = "Summary (Arabic) is required")]
        public string SummaryAr { get; set; }
        [Required(ErrorMessage = "Details (English) is required")]
        public string DetailsEn { get; set; }
        [Required(ErrorMessage = "Details (Arabic) is required")]
        public string DetailsAr { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public IFormFile LogoImage { get; set; }
        public string? LogoImageName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }
    }
    public class AddNewsWithCategory : CreateNewsDto
    {
        public IEnumerable<SelectListItem> _Categories { get; set; }

        public void InjectCategories(List<CategoryForNews> categories)
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

