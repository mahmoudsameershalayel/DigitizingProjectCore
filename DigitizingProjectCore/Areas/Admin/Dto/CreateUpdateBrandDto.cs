using System.Security.Principal;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdateBrandDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string URL { get; set; }
        public IFormFile? LogoImage { get; set; }
        public bool IsActive { get; set; }
        public bool IsPartner { get; set; }
        public int? SortId { get; set; }

    }
}
