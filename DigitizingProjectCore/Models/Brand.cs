using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Models
{
    public class Brand : BaseEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string URL { get; set; }
        public string? LogoImageName { get; set; }
        public bool IsPartner { get; set; }
        public List<Product> _Products { get; set; }
    }
}
