namespace DigitizingProjectCore.Models
{
    public class AdminLinks
    {
        public int Id { get; set; }
        public string AdminId { get; set; }
        public ApplicationUser Admin { get; set; }
        public int LinkId { get; set; }
        public Link Link { get; set; }
    }
}
