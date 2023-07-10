using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateCategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name (Arabic) is required")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "Name (English) is required")]
        public string NameEn { get; set; }
        public bool IsActive { get; set; }
        public int? SortId { get; set; }
    }
}
