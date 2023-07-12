using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class SolutionViewModel
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public CategoryForProduct Category { get; set; }
        public Brand Brand { get; set; }
        public List<SolutionProducts> SolutionProducts { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
