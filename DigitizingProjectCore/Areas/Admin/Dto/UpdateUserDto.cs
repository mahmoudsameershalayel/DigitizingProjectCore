using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } 
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
