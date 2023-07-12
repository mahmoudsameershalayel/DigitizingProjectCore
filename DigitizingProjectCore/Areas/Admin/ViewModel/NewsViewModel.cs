using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public CategoryForNews Category { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
