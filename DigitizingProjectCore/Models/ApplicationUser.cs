using DigitizingProjectCore.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage="you must insert full name!!")]
        [MaxLength(ErrorMessage = "the lenght must be less than 50!!")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "you must insert phone number!!")]
        [MaxLength(ErrorMessage = "the lenght must be less than 50!!")]
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime Created_At { get; set; } = DateTime.Now;
        public string? Created_By { get; set; }
        public DateTime Updated_at { get; set; } = DateTime.Now;
        public string? Updated_by { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<AdminLinks> AdminLinks { get; set; }
    }
}
