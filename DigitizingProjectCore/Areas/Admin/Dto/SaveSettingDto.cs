using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class SaveSettingDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "value_ar is required.")]
        public string value_ar { get; set; }
        [Required(ErrorMessage = "value_en is required.")]
        public string value_en { get; set; }
    }
}
