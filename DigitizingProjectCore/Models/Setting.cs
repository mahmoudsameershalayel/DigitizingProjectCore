using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "key_name is required.")]
        public string key_name { get; set; }
        [Required(ErrorMessage = "value_ar is required.")]
        public string value_ar { get; set; }
        [Required(ErrorMessage = "value_en is required.")]
        public string value_en { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
