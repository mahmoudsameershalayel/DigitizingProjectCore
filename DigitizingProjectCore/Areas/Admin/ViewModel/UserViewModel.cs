namespace DigitizingProjectCore.Areas.Admin.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created_At { get; set; }
    }
}
