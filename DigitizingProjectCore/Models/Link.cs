namespace DigitizingProjectCore.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string URL { get; set; }
        public string Icon { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<bool> ShowInMenu { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> ParentIdForBar { get; set; }
        public List<AdminLinks> AdminLinks { get; set; }
    }
}
