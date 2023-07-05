namespace DigitizingProjectCore.Models
{
    public class BaseEntity
    {
        public DateTime Created_At { get; set; }
        public string? Created_By { get; set; }
        public DateTime Updated_At { get; set; }
        public string? Updated_By { get; set; }
        public int SortId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
