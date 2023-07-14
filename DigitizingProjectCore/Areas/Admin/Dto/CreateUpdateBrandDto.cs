using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateBrandDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "NameAr is required.")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "NameEn is required.")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "URL is required.")]
        public string URL { get; set; }
        public IFormFile? LogoImage { get; set; }
        public string? LogoImageName { get; set; }
        public bool IsActive { get; set; }
        public bool IsPartner { get; set; }
        public int? SortId { get; set; }

    }
}
