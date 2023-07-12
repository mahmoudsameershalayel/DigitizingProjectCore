using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public CategoryForService Category { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
