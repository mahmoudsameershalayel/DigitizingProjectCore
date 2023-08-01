using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string key_name { get; set; }
        public string value_ar { get; set; }
        public string value_en { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
