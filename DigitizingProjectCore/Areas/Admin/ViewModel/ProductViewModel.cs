using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public CategoryForProduct Category { get; set; }
        public Brand Brand { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created_At { get; set; }
    }
}
