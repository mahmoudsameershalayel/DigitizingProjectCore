using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class CityViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name (Arabic) is required.")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "Name (English) is required.")]
        public string NameEn { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
