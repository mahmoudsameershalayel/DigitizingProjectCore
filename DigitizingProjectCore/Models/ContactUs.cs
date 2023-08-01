namespace DigitizingProjectCore.Models
{
    public class ContactUs : BaseEntity
    {
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsReaded { get; set; }
    }
}
