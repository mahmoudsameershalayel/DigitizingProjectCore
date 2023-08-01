using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateContactUsDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name_Is_Required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email_Is_Required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Subject_Is_Required.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Message_Is_Required.")]
        public string Message { get; set; }
    }
}
